using Microsoft.AspNetCore.Http;
using DiabetesHelper.BLL.Interfaces;
using DiabetesHelper.DAL.Models;
using DiabetesHelper.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DiabetesHelper.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserInterface _userInterface;

        public AccountController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userExist = await _userInterface.GetByEmail(model.Email);
            if (userExist != null)
            {
                ModelState.AddModelError("Email", "Email is already registered");
                return View(model);
            }

            var user = new User
            {
                FullName = model.UserName,
                Email = model.Email,
                Password = model.Password // يُفضل تشفيرها لاحقاً
            };

            await _userInterface.AddAsync(user);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userInterface.GetByEmail(model.Email);
            if (user == null || user.Password != model.Password)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View(model);
            }

            // حفظ بيانات الجلسة
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.FullName);

            // هنا يتم التوجيه إلى الصفحة التي تريدها بعد تسجيل الدخول
            return RedirectToAction("Index", "Dashboard"); // عدل إلى الصفحة التي تريدها
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = await _userInterface.GetByIdAsync(userId.Value);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var model = new UserProfileViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userInterface.GetByIdAsync(model.Id);
            if (user == null)
                return RedirectToAction("Login");

            user.FullName = model.FullName;
            user.Email = model.Email;

            await _userInterface.Update(user);

            // تحديث اسم المستخدم في الجلسة
            HttpContext.Session.SetString("UserName", user.FullName);

            ViewBag.Message = "Profile updated successfully.";
            return View(model);
        }
    }
}
using DiabetesHelper.BLL.Interfaces;
using DiabetesHelper.DAL.Models;
using DiabetesHelper.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiabetesHelper.PL.Controllers
{
    public class GlucoseReadingController : Controller
    {
        private readonly IGlucoseReadingInterface _glucoseRepo;

        public GlucoseReadingController(IGlucoseReadingInterface glucoseRepo)
        {
            _glucoseRepo = glucoseRepo;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(GlucoseReadingViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var reading = new GlucoseReading
            {
                Value = model.Value,
                Date = model.Date,
                ReadingType = model.ReadingType,
                UserId = userId.Value
            };

            await _glucoseRepo.AddAsync(reading);
            return RedirectToAction("History");
        }

        public async Task<IActionResult> History()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var readings = await _glucoseRepo.GetByUserIdAsync(userId.Value);
            return View(readings);
        }
       









    }
}


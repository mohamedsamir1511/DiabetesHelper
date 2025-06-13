using DiabetesHelper.BLL.Interfaces;
using DiabetesHelper.BLL.Repositories;
using DiabetesHelper.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesHelper.PL.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IGlucoseReadingInterface _glucoseRepo;

        // ✅ Constructor Injection
        public DashboardController(IGlucoseReadingInterface glucoseRepo)
        {
            _glucoseRepo = glucoseRepo;
        }

        public async Task<IActionResult> DashboardIndex()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var readings = await _glucoseRepo.GetByUserIdAsync(userId.Value);
            var orderedReadings = readings.OrderByDescending(r => r.Date).ToList();

            var latest = orderedReadings.FirstOrDefault();

            var model = new DashboardViewModel
            {
                LastReading = latest?.Value,
                LastReadingType = latest?.ReadingType,
                LastReadingDate = latest?.Date,
                MaxReading = readings.Any() ? readings.Max(r => r.Value) : null,
                MinReading = readings.Any() ? readings.Min(r => r.Value) : null,
                AvgReading = readings.Any() ? readings.Average(r => r.Value) : null,
                RecentReadings = orderedReadings.Take(7).Select(r => r.Value).Reverse().ToList()
            };

            return View(model);
        }
    }
}

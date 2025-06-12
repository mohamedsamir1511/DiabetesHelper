using DiabetesHelper.DAL.Enums;
using DiabetesHelper.DAL.Models;

namespace DiabetesHelper.PL.ViewModels
{
    public class DashboardViewModel
    {
        public float? LastReading { get; set; }
        public ReadingType? LastReadingType { get; set; }
        public DateTime? LastReadingDate { get; set; }

        public float? MaxReading { get; set; }
        public float? MinReading { get; set; }
        public float? AvgReading { get; set; }

        public List<float> RecentReadings { get; set; } // للـ Chart
    }


}
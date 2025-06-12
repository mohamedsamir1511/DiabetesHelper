using DiabetesHelper.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DiabetesHelper.PL.ViewModels
{
    public class GlucoseReadingViewModel
    {
        [Required]
        [Range(20, 600, ErrorMessage = "Enter a valid glucose value")]
        public float Value { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public ReadingType ReadingType { get; set; }
    }
}

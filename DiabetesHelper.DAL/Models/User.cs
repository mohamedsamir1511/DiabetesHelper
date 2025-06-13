using DiabetesHelper.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesHelper.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRole Role { get; set; }//Enum Patient Or Doctoer  Or Admin
        public float? HeightInCm {  get; set; }//if doctor will be null so nullable
        public float?WeightInKg { get; set; }

        public float? PMI
        {
            get
            {
                if(Role==UserRole.Patient && HeightInCm.HasValue && WeightInKg.HasValue)
                {
                    float heightInMeters = HeightInCm.Value / 100;
                    return (float)Math.Round(WeightInKg.Value / (heightInMeters * heightInMeters), 2);
                }
                return null;
            }

        }

        public ICollection<GlucoseReading> GlucoseReadings { get; set; }

        public ICollection<Alert> Alerts { get; set; }
    }
}

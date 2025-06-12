using DiabetesHelper.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesHelper.DAL.Models
{
    public class GlucoseReading
    {
        public int Id { get; set; }
        [Required]
        public float Value { get; set; }
        [Required]

        public DateTime Date { get; set; }
        [Required]

        public ReadingType ReadingType { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
     
     
        public User User { get; set; }


    }
}

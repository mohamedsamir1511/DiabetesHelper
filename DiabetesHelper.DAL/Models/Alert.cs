using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesHelper.DAL.Models
{
    public class Alert
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }= DateTime.Now;

        public bool IsRead { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

    }
}

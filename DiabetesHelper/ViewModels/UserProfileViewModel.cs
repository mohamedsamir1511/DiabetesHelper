using System.ComponentModel.DataAnnotations;

namespace DiabetesHelper.PL.ViewModels
{
    public class UserProfileViewModel
    {
            public int Id { get; set; }

            [Required]
            public string FullName { get; set; }

            [Required, EmailAddress]
            public string Email { get; set; }
        }
    }



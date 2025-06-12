using System.ComponentModel.DataAnnotations;

namespace DiabetesHelper.PL.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]  
        public string Password { get; set; }
        [Required,DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword {  get; set; }
        public string Role {  get; set; }
    }
}

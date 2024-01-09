using System.ComponentModel.DataAnnotations;

namespace SchoolWebsite.ViewModels
{
    public class Register
    {
        [Display(Name ="Enter Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Enter Password")]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Display(Name = "Re-Enter Password")]
        public string ConfirmPassword { get; set; }
    }
}

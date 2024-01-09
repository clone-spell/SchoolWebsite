using System.ComponentModel.DataAnnotations;

namespace SchoolWebsite.ViewModels
{
    public class Login
    {
        [Display(Name = "Enter Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Enter Password")]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}

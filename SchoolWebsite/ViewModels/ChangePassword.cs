using System.ComponentModel.DataAnnotations;

namespace SchoolWebsite.ViewModels
{
    public class ChangePassword
    {
        [Display(Name ="Enter Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Enter Current Password")]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Enter New Password")]
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword))]
        [DataType(DataType.Password)]
        [Display(Name = "Re-Enter New Password")]
        public string ConfirmNewPassword { get; set; }
    }
}

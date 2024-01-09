using System.ComponentModel.DataAnnotations;

namespace SchoolWebsite.Models
{
    public class Contact
    {
        public Guid Id { get; set; }


        [DataType(DataType.EmailAddress)]
        [Display(Name ="Enter Email Address")]
        public string Email { get; set; }


        [StringLength(500, MinimumLength =3)]
        public string Message { get; set; }
        public DateTime ContactDate { get; set; } = DateTime.Now;
    }
}

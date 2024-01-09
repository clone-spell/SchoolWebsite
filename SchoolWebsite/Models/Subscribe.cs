using System.ComponentModel.DataAnnotations;

namespace SchoolWebsite.Models
{
    public class Subscribe
    {
        public Guid Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime SubscribeDateTime { get; set; } = DateTime.Now;
    }
}

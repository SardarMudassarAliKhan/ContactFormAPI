using System.ComponentModel.DataAnnotations;

namespace ContactFormAPI.Model
{
    public class ContactForm
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}

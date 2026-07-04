using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.ViewModels
{
    public class ContactVM
    {
        public string? AuthorPhoneNumber { get; set; }
        public string? AuthorEmail { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}

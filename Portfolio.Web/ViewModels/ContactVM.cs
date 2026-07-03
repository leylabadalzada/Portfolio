using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.ViewModels
{
    public class ContactVM
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}

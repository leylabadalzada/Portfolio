using Portfolio.Service.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Service.ViewModels.Author
{
    public record AuthorUpdateVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateVM BirthDate { get; set; }
        public string Location { get; set; }
        public string Info { get; set; } //homepage introduction
        public string Description { get; set; } //aboutpage 
        [RegularExpression(@"^(?:(?:\+994|0))(10|50|51|55|60|70|77|99)\d{7}$")]
        public string PhoneNumber { get; set; }
        public bool isFreelanceAvailable { get; set; }
    }
}

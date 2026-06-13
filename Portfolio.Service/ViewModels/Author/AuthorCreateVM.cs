using Microsoft.AspNetCore.Http;
using Portfolio.Service.ViewModels.General;

namespace Portfolio.Service.ViewModels.Author
{
    public record AuthorCreateVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile Image { get; set; }
        public DateVM BirthDate { get; set; }
        public string Location { get; set; }
        public string Info { get; set; } //homepage introduction
        public string Description { get; set; } //aboutpage 
        public bool isFreelanceAvailable { get; set; }
    }
}

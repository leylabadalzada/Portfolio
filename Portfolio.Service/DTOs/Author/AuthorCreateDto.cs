using Microsoft.AspNetCore.Http;
using Portfolio.Service.DTOs.General;

namespace Portfolio.Service.DTOs.Author
{
    public class AuthorCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile Image { get; set; }
        public DateDto BirthDate { get; set; }
        public string Location { get; set; }
        public string Info { get; set; } //homepage introduction
        public string Description { get; set; } //aboutpage 
        public bool isFreelanceAvailable { get; set; }
    }
}

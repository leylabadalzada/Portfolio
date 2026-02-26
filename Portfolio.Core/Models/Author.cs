using Portfolio.Core.Models.BaseModels;

namespace Portfolio.Core.Models
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageName { get; set; }
        public string? ImageURL { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Location { get; set; }
        public string Info { get; set; } //homepage introduction
        public string Description { get; set; } //aboutpage 
        public bool isFreelanceAvailable { get; set; }
    }
}

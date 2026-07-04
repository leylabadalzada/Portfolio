using Microsoft.AspNetCore.Identity;

namespace Portfolio.Core.Models
{
    public class Author : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Location { get; set; }
        public string Info { get; set; } //homepage introduction
        public string Description { get; set; } //aboutpage 
        public bool isFreelanceAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}

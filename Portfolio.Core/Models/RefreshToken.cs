using Portfolio.Core.Models.BaseModels;

namespace Portfolio.Core.Models
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

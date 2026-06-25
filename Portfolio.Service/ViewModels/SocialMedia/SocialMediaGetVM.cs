using Portfolio.Core.Enums;

namespace Portfolio.Service.ViewModels.SocialMedia
{
    public record SocialMediaGetVM
    {
        public string Id { get; set; }
        public SocialMediaName SocialMediaName { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

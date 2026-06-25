using Portfolio.Core.Enums;

namespace Portfolio.Service.ViewModels.SocialMedia
{
    public record SocialMediaCreateOrUpdateVM
    {
        public SocialMediaName SocialMediaName { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
    }
}

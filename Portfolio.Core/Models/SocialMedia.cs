using Portfolio.Core.Enums;
using Portfolio.Core.Models.BaseModels;

namespace Portfolio.Core.Models
{
    public class SocialMedia : BaseEntity
    {
        public SocialMediaName SocialMediaName { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
    }
}

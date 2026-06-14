using Portfolio.Core.Models.BaseModels;

namespace Portfolio.Core.Models
{
    public class Resume : BaseEntity
    {
        public string Filename { get; set; }
        public bool IsSelected { get; set; }
    }
}

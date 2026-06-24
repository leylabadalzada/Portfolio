using Portfolio.Core.Enums;
using Portfolio.Core.Models.BaseModels;

namespace Portfolio.Core.Models
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public LanguageValue Level { get; set; }
    }
}

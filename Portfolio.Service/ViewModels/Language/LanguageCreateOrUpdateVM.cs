using Portfolio.Core.Enums;

namespace Portfolio.Service.ViewModels.Language
{
    public record LanguageCreateOrUpdateVM
    {
        public string Name { get; set; }
        public LanguageValue Level { get; set; }
    }
}

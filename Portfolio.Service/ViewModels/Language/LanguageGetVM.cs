using Portfolio.Core.Enums;

namespace Portfolio.Service.ViewModels.Language
{
    public record LanguageGetVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LevelName { get; set; }
        public LanguageValue Level { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

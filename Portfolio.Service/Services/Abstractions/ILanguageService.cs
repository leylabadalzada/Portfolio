using Portfolio.Service.ViewModels.Language;

namespace Portfolio.Service.Services.Abstractions
{
    public interface ILanguageService
    {
        Task<bool> CreateAsync(LanguageCreateOrUpdateVM vm);
        Task<List<LanguageGetVM>> GetAllAsync();
        Task<LanguageGetVM> GetSingleAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, LanguageCreateOrUpdateVM vm);
    }
}

using Portfolio.Service.ViewModels.Language;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Abstractions
{
    public interface ILanguageService
    {
        Task<ResponseVM> CreateAsync(LanguageCreateOrUpdateVM vm);
        Task<ResponseVM<List<LanguageGetVM>>> GetAllAsync();
        Task<ResponseVM<LanguageGetVM>> GetSingleAsync(Guid id);
        Task<ResponseVM> RemoveAsync(Guid id);
        Task<ResponseVM> UpdateAsync(Guid id, LanguageCreateOrUpdateVM vm);
    }
}

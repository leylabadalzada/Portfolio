using Portfolio.Service.ViewModels.Experience;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IExperienceService
    {
        Task<ResponseVM> CreateAsync(ExperienceCreateOrUpdateVM vm);
        Task<ResponseVM> RemoveAsync(Guid id);
        Task<ResponseVM> UpdateAsync(Guid id, ExperienceCreateOrUpdateVM vm);

        Task<ResponseVM<List<ExperienceGetVM>>> GetAllAsync();
        Task<ResponseVM<ExperienceGetVM>> GetAsync(Guid id);
    }
}

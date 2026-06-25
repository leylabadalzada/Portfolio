using Portfolio.Service.ViewModels.Experience;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IExperienceService
    {
        Task<bool> CreateAsync(ExperienceCreateOrUpdateVM vm);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, ExperienceCreateOrUpdateVM vm);

        Task<List<ExperienceGetVM>> GetAllAsync();
        Task<ExperienceGetVM> GetAsync(Guid id);
    }
}

using Portfolio.Service.ViewModels.Education;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IEducationService
    {
        Task<bool> CreateAsync(EducationCreateOrUpdateVM vm);
        Task<List<EducationGetVM>> GetAllAsync();
        Task<EducationGetVM> GetAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, EducationCreateOrUpdateVM vm);
    }
}

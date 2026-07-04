using Portfolio.Service.ViewModels.Education;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IEducationService
    {
        Task<ResponseVM> CreateAsync(EducationCreateOrUpdateVM vm);
        Task<ResponseVM<List<EducationGetVM>>> GetAllAsync();
        Task<ResponseVM<EducationGetVM>> GetAsync(Guid id);
        Task<ResponseVM> RemoveAsync(Guid id);
        Task<ResponseVM> UpdateAsync(Guid id, EducationCreateOrUpdateVM vm);
    }
}

using Portfolio.Service.ViewModels.Project;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IProjectService
    {
        Task<ResponseVM> CreateAsync(ProjectCreateVM vm);
        Task<ResponseVM<List<ProjectGetVM>>> GetAllAsync();
        Task<ResponseVM<ProjectGetVM>> GetAsync(Guid id);
        Task<ResponseVM> RemoveAsync(Guid id);
        Task<ResponseVM> UpdateAsync(Guid id, ProjectUpdateVM vm);
    }
}

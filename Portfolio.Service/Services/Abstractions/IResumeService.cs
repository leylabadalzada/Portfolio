using Portfolio.Service.ViewModels.Response;
using Portfolio.Service.ViewModels.Resumes;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IResumeService
    {
        Task<ResponseVM> CreateAsync(ResumeCreateVM vm);
        public Task<ResponseVM<List<ResumeGetVM>>> GetAsync();
        Task<ResponseVM<ResumeGetVM>> GetSelectedResumeAsync();
        Task<ResponseVM> RemoveAsync(Guid id);
        Task<ResponseVM> SelectResumeAsync(Guid id);
    }
}

//todo: selectresume, remove

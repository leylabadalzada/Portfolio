using Portfolio.Service.ViewModels.Resumes;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IResumeService
    {
        Task<bool> CreateAsync(ResumeCreateVM vm);
        public Task<List<ResumeGetVM>> GetAsync();
        Task<ResumeGetVM> GetSelectedResumeAsync();
        Task<bool> RemoveAsync(Guid id);
        Task<bool> SelectResumeAsync(Guid id);
    }
}

//todo: selectresume, remove

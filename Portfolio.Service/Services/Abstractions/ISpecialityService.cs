using Portfolio.Service.ViewModels.Speciality;

namespace Portfolio.Service.Services.Abstractions
{
    public interface ISpecialityService
    {
        Task<bool> CreateAsync(SpecialityCreateVM vm);
        Task<List<SpecialityGetVM>> GetAsync();
        Task<string> GetAllAsync();
        Task<string> GetAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> SetMainAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, SpecialityUpdateVM vm);
    }
}

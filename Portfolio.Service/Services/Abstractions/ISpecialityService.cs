using Portfolio.Service.ViewModels.Response;
using Portfolio.Service.ViewModels.Speciality;

namespace Portfolio.Service.Services.Abstractions
{
    public interface ISpecialityService
    {
        Task<ResponseVM> CreateAsync(SpecialityCreateVM vm);
        Task<ResponseVM<List<SpecialityGetVM>>> GetAllAsync();
        Task<ResponseVM<string>> GetMainAsync();
        Task<ResponseVM<string>> GetAsync(Guid id);
        Task<ResponseVM> RemoveAsync(Guid id);
        Task<ResponseVM> SetMainAsync(Guid id);
        Task<ResponseVM> UpdateAsync(Guid id, SpecialityUpdateVM vm);
    }
}

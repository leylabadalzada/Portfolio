using Portfolio.Service.ViewModels.Field;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IFieldService
    {
        Task<ResponseVM> CreateAsync(FieldCreateOrUpdateVM vm);
        Task<ResponseVM<List<FieldGetVM>>> GetAllAsync();
        Task<ResponseVM<FieldGetVM>> GetAsync(Guid id);
        Task<ResponseVM> RemoveAsync(Guid id);
        Task<ResponseVM> UpdateAsync(Guid id, FieldCreateOrUpdateVM vm);
    }
}

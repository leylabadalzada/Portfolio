using Portfolio.Service.ViewModels.Response;
using Portfolio.Service.ViewModels.Skill;

namespace Portfolio.Service.Services.Abstractions
{
    public interface ISkillService
    {
        Task<ResponseVM> CreateAsync(SkillCreateVM vm);
        Task<ResponseVM<List<SkillGetVM>>> GetAllAsync();
        Task<ResponseVM<SkillGetVM>> GetAsync(Guid id);
        Task<ResponseVM> RemoveAsync(Guid id);
        Task<ResponseVM> UpdateAsync(Guid id, SkillUpdateVM vm);
    }
}

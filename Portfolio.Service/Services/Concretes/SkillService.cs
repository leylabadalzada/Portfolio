using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Enums;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Response;
using Portfolio.Service.ViewModels.Skill;

namespace Portfolio.Service.Services.Concretes
{
    public class SkillService : ISkillService
    {
        readonly AppDbContext _context;

        public SkillService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseVM> CreateAsync(SkillCreateVM vm)
        {
            var field = await _context.Fields.FindAsync(vm.FieldId);
            if (field == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Field") };
            var skill = new Skill
            {
                Name = vm.Name,
                Description = vm.Description,
                FieldId = field.ID
            };

            var result = await _context.AddAsync(skill);
            if (result.State != EntityState.Added) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Add) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ?
                new ResponseVM { Result = true, Message = ResponseMessage.SuccessMessage("Created") }
                : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM<List<SkillGetVM>>> GetAllAsync()
        {
            var skills = _context.Skills.Include(s => s.Field).AsNoTracking();
            return new ResponseVM<List<SkillGetVM>>
            {
                Data = await skills.Select(skill => skill.ToSkillGetVM()).ToListAsync(),
                Message = $"Count:{skills.Count()}"
            };
        }

        public async Task<ResponseVM<SkillGetVM>> GetAsync(Guid id)
        {
            var skill = await _context.Skills.Include(s => s.Field).FirstOrDefaultAsync(s => s.ID == id);
            return new ResponseVM<SkillGetVM>
            {
                Data = skill.ToSkillGetVM()
            };
        }

        public async Task<ResponseVM> RemoveAsync(Guid id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Skill") };
            var result = _context.Remove(skill);
            if (result.State != EntityState.Deleted) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Remove) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ?
                new ResponseVM { Result = true, Message = ResponseMessage.SuccessMessage("Removed") }
                : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };

        }

        public async Task<ResponseVM> UpdateAsync(Guid id, SkillUpdateVM vm)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Skill") };

            skill.Name = vm.Name;
            skill.Description = vm.Description;

            var result = _context.Update(skill);
            if (result.State != EntityState.Modified) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Update) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ?
                new ResponseVM { Result = true, Message = ResponseMessage.SuccessMessage("Updated") }
                : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };

        }
    }
}

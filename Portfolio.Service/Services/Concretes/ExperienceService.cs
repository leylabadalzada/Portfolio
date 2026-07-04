using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Enums;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.Utils;
using Portfolio.Service.ViewModels.Experience;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Concretes
{
    public class ExperienceService : IExperienceService
    {
        readonly AppDbContext _context;

        public ExperienceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseVM> CreateAsync(ExperienceCreateOrUpdateVM vm)
        {
            var experience = new Experience
            {
                Description = vm.Description,
                isContinuing = vm.isContinuing,
                Position = vm.Position,
                Company = vm.Company,
                StartDate = DateOnlyUtils.GenerateDate(vm.StartDate.Day, vm.StartDate.Month, vm.StartDate.Year),
                EndDate = vm.isContinuing ? null : DateOnlyUtils.GenerateDate(vm.EndDate.Day, vm.EndDate.Month, vm.EndDate.Year)
            };
            //todo: startdate ve enddate ucun xususi validationlar lazimdir.
            var result = await _context.AddAsync(experience);
            if (result.State != EntityState.Added) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Add) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Created") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM<List<ExperienceGetVM>>> GetAllAsync()
        {
            return new ResponseVM<List<ExperienceGetVM>> { Data = await _context.Experiences.AsNoTracking().OrderByDescending(e => e.CreatedAt).Select(experience => experience.ToExperienceGetVM()).ToListAsync() };
        }

        public async Task<ResponseVM<ExperienceGetVM>> GetAsync(Guid id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            return experience == null ? new ResponseVM<ExperienceGetVM> { Result = false, Message = ResponseMessage.NotFoundMessage("Experience") } :
                new ResponseVM<ExperienceGetVM> { Data = experience.ToExperienceGetVM() };
        }



        public async Task<ResponseVM> RemoveAsync(Guid id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Experience") };
            var result = _context.Remove(experience);
            if (result.State != EntityState.Deleted) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Remove) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Removed") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM> UpdateAsync(Guid id, ExperienceCreateOrUpdateVM vm)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Experience") };

            experience.Description = vm.Description;
            experience.isContinuing = vm.isContinuing;
            experience.Position = vm.Position;
            experience.Company = vm.Company;
            experience.StartDate = DateOnlyUtils.GenerateDate(vm.StartDate.Day, vm.StartDate.Month, vm.StartDate.Year);
            experience.EndDate = vm.isContinuing ? null : DateOnlyUtils.GenerateDate(vm.EndDate.Day, vm.EndDate.Month, vm.EndDate.Year);

            var result = _context.Update(experience);
            if (result.State != EntityState.Modified) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Update) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Updated") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }
    }
}

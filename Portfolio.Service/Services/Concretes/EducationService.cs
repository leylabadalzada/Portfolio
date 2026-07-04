using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Enums;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.Utils;
using Portfolio.Service.ViewModels.Education;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Concretes
{
    public class EducationService : IEducationService
    {
        readonly AppDbContext _context;

        public EducationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseVM> CreateAsync(EducationCreateOrUpdateVM vm)
        {
            var education = new Education
            {
                Description = vm.Description,
                isContinuing = vm.isContinuing,
                Speciality = vm.Speciality,
                University = vm.University,
                StartDate = DateOnlyUtils.GenerateDate(vm.StartDate.Day, vm.StartDate.Month, vm.StartDate.Year),
                EndDate = vm.isContinuing ? null : DateOnlyUtils.GenerateDate(vm.EndDate.Day, vm.EndDate.Month, vm.EndDate.Year)
            };
            //todo: startdate ve enddate ucun xususi validationlar lazimdir.
            var result = await _context.AddAsync(education);
            if (result.State != EntityState.Added) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Add) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Created") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM<List<EducationGetVM>>> GetAllAsync()
        {
            return new ResponseVM<List<EducationGetVM>> { Data = await _context.Educations.AsNoTracking().OrderByDescending(e => e.CreatedAt).Select(education => education.ToEducationGetVM()).ToListAsync() };
        }

        public async Task<ResponseVM<EducationGetVM>> GetAsync(Guid id)
        {
            var education = await _context.Educations.FindAsync(id);
            return education == null ? new ResponseVM<EducationGetVM> { Result = false, Message = ResponseMessage.NotFoundMessage("Education") } :
                new ResponseVM<EducationGetVM> { Data = education.ToEducationGetVM() };
        }

        public async Task<ResponseVM> RemoveAsync(Guid id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Education") };
            var result = _context.Remove(education);
            if (result.State != EntityState.Deleted) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Remove) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Removed") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM> UpdateAsync(Guid id, EducationCreateOrUpdateVM vm)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Education") };

            education.Description = vm.Description;
            education.isContinuing = vm.isContinuing;
            education.Speciality = vm.Speciality;
            education.University = vm.University;
            education.StartDate = DateOnlyUtils.GenerateDate(vm.StartDate.Day, vm.StartDate.Month, vm.StartDate.Year);
            education.EndDate = vm.isContinuing ? null : DateOnlyUtils.GenerateDate(vm.EndDate.Day, vm.EndDate.Month, vm.EndDate.Year);

            var result = _context.Update(education);
            if (result.State != EntityState.Added) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Update) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Updated") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }
    }
}

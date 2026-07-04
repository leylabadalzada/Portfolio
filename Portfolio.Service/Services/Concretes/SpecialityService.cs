using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Enums;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Response;
using Portfolio.Service.ViewModels.Speciality;

namespace Portfolio.Service.Services.Concretes
{
    public class SpecialityService : ISpecialityService
    {
        readonly AppDbContext _context;

        public SpecialityService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseVM<List<SpecialityGetVM>>> GetAllAsync()
        {
            return new ResponseVM<List<SpecialityGetVM>>
            {
                Data = await _context.Specialities.AsNoTracking().OrderByDescending(s => s.CreatedAt).Select(s => s.ToSpecialityGetVM()).ToListAsync()
            };
        }

        public async Task<ResponseVM> CreateAsync(SpecialityCreateVM vm)
        {
            var speciality = new Speciality
            {
                Name = vm.Name,
                IsMain = vm.IsMain
            };

            var result = await _context.AddAsync(speciality);
            if (result.State != EntityState.Added) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Add) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Created") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM<string>> GetMainAsync()
        {
            var speciality = await _context.Specialities.OrderByDescending(e => e.CreatedAt).AsNoTracking().FirstOrDefaultAsync(s => s.IsMain);
            return speciality == null ? new ResponseVM<string>
            {
                Message = ResponseMessage.NotFoundMessage("Speciality"),
                Result = false
            } : new ResponseVM<string> { Data = speciality.Name };
        }

        public async Task<ResponseVM<string>> GetAsync(Guid id)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            return speciality == null ? new ResponseVM<string>
            {
                Message = ResponseMessage.NotFoundMessage("Speciality"),
                Result = false
            } : new ResponseVM<string> { Data = speciality.Name };
        }

        public async Task<ResponseVM> SetMainAsync(Guid id)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null) return new ResponseVM
            {
                Message = ResponseMessage.NotFoundMessage("Speciality"),
                Result = false
            };

            speciality.IsMain = true;

            var result = _context.Update(speciality);
            if (result.State != EntityState.Modified) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Update) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Updated") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM> RemoveAsync(Guid id)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null) return new ResponseVM
            {
                Message = ResponseMessage.NotFoundMessage("Speciality"),
                Result = false
            };


            var result = _context.Remove(speciality);
            if (result.State != EntityState.Deleted) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Update) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Removed") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM> UpdateAsync(Guid id, SpecialityUpdateVM vm)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null) return new ResponseVM
            {
                Message = ResponseMessage.NotFoundMessage("Speciality"),
                Result = false
            };

            speciality.Name = vm.Name;

            var result = _context.Update(speciality);
            if (result.State != EntityState.Modified) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Update) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Updated") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }
    }
}

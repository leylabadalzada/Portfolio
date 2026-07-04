using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Enums;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Language;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Concretes
{
    public class LanguageService : ILanguageService
    {
        private readonly AppDbContext _context;

        public LanguageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseVM<List<LanguageGetVM>>> GetAllAsync()
        {
            return new ResponseVM<List<LanguageGetVM>> { Data = await _context.Languages.AsNoTracking().OrderByDescending(e => e.CreatedAt).Select(language => language.ToLanguageGetVM()).ToListAsync() };
        }

        public async Task<ResponseVM> CreateAsync(LanguageCreateOrUpdateVM vm)
        {
            var language = new Language
            {
                Name = vm.Name,
                Level = vm.Level
            };
            var result = await _context.AddAsync(language);
            if (result.State != EntityState.Added) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Add) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Created") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM<LanguageGetVM>> GetSingleAsync(Guid id)
        {
            var language = await _context.Languages.FindAsync(id);
            return language == null ? new ResponseVM<LanguageGetVM> { Result = false, Message = ResponseMessage.NotFoundMessage("Language") } :
                new ResponseVM<LanguageGetVM> { Data = language.ToLanguageGetVM() };
        }

        public async Task<ResponseVM> UpdateAsync(Guid id, LanguageCreateOrUpdateVM vm)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Language") };

            language.Name = vm.Name;
            language.Level = vm.Level;

            var result = _context.Update(language);
            if (result.State != EntityState.Modified) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Update) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Updated") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM> RemoveAsync(Guid id)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Language") };


            var result = _context.Remove(language);
            if (result.State != EntityState.Deleted) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Remove) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Removed") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }
    }
}

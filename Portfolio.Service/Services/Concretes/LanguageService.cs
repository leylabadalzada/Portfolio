using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Language;

namespace Portfolio.Service.Services.Concretes
{
    public class LanguageService : ILanguageService
    {
        private readonly AppDbContext _context;

        public LanguageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageGetVM>> GetAllAsync()
        {
            return await _context.Languages.AsNoTracking().OrderByDescending(e => e.CreatedAt).Select(language => language.ToLanguageGetVM()).ToListAsync();
        }

        public async Task<bool> CreateAsync(LanguageCreateOrUpdateVM vm)
        {
            var language = new Language
            {
                Name = vm.Name,
                Level = vm.Level
            };
            var result = await _context.AddAsync(language);
            if (result.State != EntityState.Added) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<LanguageGetVM> GetSingleAsync(Guid id)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language == null) throw new Exception("Language not found");
            return language.ToLanguageGetVM();
        }

        public async Task<bool> UpdateAsync(Guid id, LanguageCreateOrUpdateVM vm)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language == null) return false;

            language.Name = vm.Name;
            language.Level = vm.Level;

            var result = _context.Update(language);
            if (result.State != EntityState.Modified) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language == null) return false;
            ;

            var result = _context.Remove(language);
            if (result.State != EntityState.Deleted) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }
    }
}

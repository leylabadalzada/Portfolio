using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Exceptions;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
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

        public async Task<List<SpecialityGetVM>> GetAsync()
        {
            var specialities = await _context.Specialities.AsNoTracking().OrderByDescending(s => s.CreatedAt).ToListAsync();
            var vms = specialities.Select(s => s.ToSpecialityGetVM()).ToList();
            return vms;
        }

        public async Task<bool> CreateAsync(SpecialityCreateVM vm)
        {
            var speciality = new Speciality
            {
                Name = vm.Name,
                IsMain = vm.IsMain
            };

            var result = await _context.AddAsync(speciality);
            if (result.State != EntityState.Added) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<string> GetSpecialityAsync()
        {
            var speciality = await _context.Specialities.AsNoTracking().FirstOrDefaultAsync(s => s.IsMain);
            if (speciality == null) throw new NotFoundException("speciality");

            return speciality.Name;
        }

        public async Task<string> GetSpecialityAsync(Guid id)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null) throw new NotFoundException("speciality");

            return speciality.Name;
        }

        public async Task<bool> SetMainAsync(Guid id)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null) throw new NotFoundException("speciality");

            speciality.IsMain = true;

            var result = _context.Update(speciality);
            if (result.State != EntityState.Modified) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null) throw new NotFoundException("speciality");


            var result = _context.Remove(speciality);
            if (result.State != EntityState.Deleted) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, SpecialityUpdateVM vm)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null) throw new NotFoundException("speciality");

            speciality.Name = vm.Name;

            var result = _context.Update(speciality);
            if (result.State != EntityState.Modified) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }
    }
}

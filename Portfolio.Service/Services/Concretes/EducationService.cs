using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.Utils;
using Portfolio.Service.ViewModels.Education;

namespace Portfolio.Service.Services.Concretes
{
    public class EducationService : IEducationService
    {
        readonly AppDbContext _context;

        public EducationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(EducationCreateOrUpdateVM vm)
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
            if (result.State != EntityState.Added) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<List<EducationGetVM>> GetAllAsync()
        {
            return await _context.Educations.AsNoTracking().OrderByDescending(e => e.CreatedAt).Select(education => education.ToEducationGetVM()).ToListAsync();
        }

        public async Task<EducationGetVM> GetAsync(Guid id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null) throw new Exception("Education not found");
            return education.ToEducationGetVM();
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null) return false;
            var result = _context.Remove(education);
            if (result.State != EntityState.Deleted) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, EducationCreateOrUpdateVM vm)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null) return false;

            education.Description = vm.Description;
            education.isContinuing = vm.isContinuing;
            education.Speciality = vm.Speciality;
            education.University = vm.University;
            education.StartDate = DateOnlyUtils.GenerateDate(vm.StartDate.Day, vm.StartDate.Month, vm.StartDate.Year);
            education.EndDate = vm.isContinuing ? null : DateOnlyUtils.GenerateDate(vm.EndDate.Day, vm.EndDate.Month, vm.EndDate.Year);

            var result = _context.Update(education);
            if (result.State != EntityState.Modified) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }
    }
}

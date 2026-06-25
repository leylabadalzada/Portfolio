using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.Utils;
using Portfolio.Service.ViewModels.Experience;

namespace Portfolio.Service.Services.Concretes
{
    public class ExperienceService : IExperienceService
    {
        readonly AppDbContext _context;

        public ExperienceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(ExperienceCreateOrUpdateVM vm)
        {
            var education = new Experience
            {
                Description = vm.Description,
                isContinuing = vm.isContinuing,
                Position = vm.Position,
                Company = vm.Company,
                StartDate = DateOnlyUtils.GenerateDate(vm.StartDate.Day, vm.StartDate.Month, vm.StartDate.Year),
                EndDate = vm.isContinuing ? null : DateOnlyUtils.GenerateDate(vm.EndDate.Day, vm.EndDate.Month, vm.EndDate.Year)
            };
            //todo: startdate ve enddate ucun xususi validationlar lazimdir.
            var result = await _context.AddAsync(education);
            if (result.State != EntityState.Added) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<List<ExperienceGetVM>> GetAllAsync()
        {
            return await _context.Experiences.AsNoTracking().OrderByDescending(e => e.CreatedAt).Select(experience => experience.ToExperienceGetVM()).ToListAsync();
        }

        public async Task<ExperienceGetVM> GetAsync(Guid id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null) throw new Exception("Experience not found");
            return experience.ToExperienceGetVM();
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

        public async Task<bool> UpdateAsync(Guid id, ExperienceCreateOrUpdateVM vm)
        {
            var education = await _context.Experiences.FindAsync(id);
            if (education == null) return false;

            education.Description = vm.Description;
            education.isContinuing = vm.isContinuing;
            education.Position = vm.Position;
            education.Company = vm.Company;
            education.StartDate = DateOnlyUtils.GenerateDate(vm.StartDate.Day, vm.StartDate.Month, vm.StartDate.Year);
            education.EndDate = vm.isContinuing ? null : DateOnlyUtils.GenerateDate(vm.EndDate.Day, vm.EndDate.Month, vm.EndDate.Year);

            var result = _context.Update(education);
            if (result.State != EntityState.Modified) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }
    }
}

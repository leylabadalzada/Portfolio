using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Field;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Concretes
{
    public class FieldService : IFieldService
    {
        readonly AppDbContext _context;

        public FieldService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseVM<List<FieldGetVM>>> GetAllAsync()
        {
            return new ResponseVM<List<FieldGetVM>>
            {
                Result = true,
                Data = await _context.Fields.Select(field => field.ToFieldGetVM()).ToListAsync()
            };
        }

        public async Task<ResponseVM> CreateAsync(FieldCreateOrUpdateVM vm)
        {
            var field = new Field { FieldName = vm.FieldName };
            var result = await _context.AddAsync(field);
            if (result.State != EntityState.Added) return new ResponseVM { Result = false, Message = "Add failed!" };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Result = true, Message = "Created Successfully!" } : new ResponseVM { Result = false, Message = "Save failed!" };
        }


        public async Task<ResponseVM<FieldGetVM>> GetAsync(Guid id)
        {
            var field = await _context.Fields.FindAsync(id);
            if (field == null) return new ResponseVM<FieldGetVM> { Result = false, Message = "Field not found" };

            return new ResponseVM<FieldGetVM> { Result = true, Data = field.ToFieldGetVM() };
        }

        public async Task<ResponseVM> RemoveAsync(Guid id)
        {
            var field = await _context.Fields.FindAsync(id);
            if (field == null) return new ResponseVM { Result = false, Message = "Field not found" };

            var result = _context.Remove(field);
            if (result.State != EntityState.Deleted) return new ResponseVM { Result = false, Message = "Remove failed!" };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Result = true, Message = "Removed Successfully!" } : new ResponseVM { Result = false, Message = "Save failed!" };
        }

        public async Task<ResponseVM> UpdateAsync(Guid id, FieldCreateOrUpdateVM vm)
        {
            var field = await _context.Fields.FindAsync(id);
            if (field == null) return new ResponseVM { Result = false, Message = "Field not found" };

            field.FieldName = vm.FieldName;

            var result = _context.Update(field);
            if (result.State != EntityState.Modified) return new ResponseVM { Result = false, Message = "Update failed!" };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Result = true, Message = "Updated Successfully!" } : new ResponseVM { Result = false, Message = "Save failed!" };
        }
    }
}


using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Enums;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Project;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Concretes
{
    public class ProjectService : IProjectService
    {
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;

        public ProjectService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<ResponseVM> CreateAsync(ProjectCreateVM vm)
        {
            var project = new Project
            {
                ProjectName = vm.ProjectName,
                Description = vm.Description,
                GitHubURL = vm.GitHubURL,
                IsFeatured = vm.IsFeatured,
                LiveURL = vm.LiveURL,
                ShortDescription = vm.ShortDescription,
                Image = vm.Image.UploadFile(_env.WebRootPath, FilePaths.ProjectPath)
            };

            var result = await _context.AddAsync(project);
            if (result.State != EntityState.Added) return new ResponseVM { Message = ResponseMessage.FailMessage(ResponseMessageContent.Add), Result = false };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ?
                new ResponseVM { Result = true, Message = ResponseMessage.SuccessMessage("Created") }
                : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM<List<ProjectGetVM>>> GetAllAsync()
        {
            var projects = _context.Projects.AsNoTracking();
            var dtos = await projects.Select(project => project.ToProjectGetVM()).ToListAsync();
            return new ResponseVM<List<ProjectGetVM>> { Data = dtos, Message = $"Count: {projects.Count()}" };
        }

        public async Task<ResponseVM<ProjectGetVM>> GetAsync(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            return project == null ? new ResponseVM<ProjectGetVM>
            {
                Message = ResponseMessage.NotFoundMessage("Project"),
                Result = false
            } : new ResponseVM<ProjectGetVM> { Data = project.ToProjectGetVM() };
        }

        public async Task<ResponseVM> RemoveAsync(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return new ResponseVM { Message = ResponseMessage.NotFoundMessage("Project"), Result = false };
            var result = _context.Remove(project);
            if (result.State != EntityState.Deleted) return new ResponseVM { Message = ResponseMessage.FailMessage(ResponseMessageContent.Remove), Result = false };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ?
                new ResponseVM { Result = true, Message = ResponseMessage.SuccessMessage("Removed") }
                : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM> UpdateAsync(Guid id, ProjectUpdateVM vm)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return new ResponseVM { Message = ResponseMessage.NotFoundMessage("Project"), Result = false };

            project.LiveURL = vm.LiveURL;
            project.IsFeatured = vm.IsFeatured;
            project.ShortDescription = vm.ShortDescription;
            project.Description = vm.Description;
            project.GitHubURL = vm.GitHubURL;
            project.ProjectName = vm.ProjectName;

            if (vm.Image != null)
            {
                var path = Path.Combine(_env.WebRootPath, FilePaths.ProjectPath, project.Image);
                path.DeleteFile();

                project.Image = vm.Image.UploadFile(_env.WebRootPath, FilePaths.ProjectPath);
            }

            var result = _context.Update(project);
            if (result.State != EntityState.Modified) return new ResponseVM { Message = ResponseMessage.FailMessage(ResponseMessageContent.Remove), Result = false };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ?
                new ResponseVM { Result = true, Message = ResponseMessage.SuccessMessage("Updated") }
                : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }
    }
}

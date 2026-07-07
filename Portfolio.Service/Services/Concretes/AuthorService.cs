using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Enums;
using Portfolio.Core.Models;
using Portfolio.Service.Exceptions;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.Utils;
using Portfolio.Service.ViewModels.Author;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Concretes
{
    public class AuthorService : IAuthorService
    {
        readonly UserManager<Author> _userManager;
        readonly IOtpService _otpService;
        readonly IEmailService _emailService;
        readonly IWebHostEnvironment _env;

        public AuthorService(UserManager<Author> userManager, IWebHostEnvironment env, IOtpService otpService, IEmailService emailService)
        {
            _userManager = userManager;
            _env = env;
            _otpService = otpService;
            _emailService = emailService;
        }

        public async Task<ResponseVM<AuthorGetVM>> GetAsync()
        {
            var author = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync();
            if (author == null) return new ResponseVM<AuthorGetVM> { Result = false, Message = ResponseMessage.NotFoundMessage("Author") };
            return new ResponseVM<AuthorGetVM> { Data = author.ToAuthorGetVM() };
        }

        public async Task<ResponseVM> ChangeImageAsync(ChangeImageVM vm)
        {
            var author = await _userManager.Users.FirstOrDefaultAsync();
            if (author == null) throw new NotFoundException("Author");
            if (!author.ImageName.Contains("default.png"))
            {
                var path = Path.Combine(_env.WebRootPath, FilePaths.AuthorPath, author.ImageName);
                if (File.Exists(path)) File.Delete(path);
            }

            author.ImageName = vm.NewImage.UploadFile(_env.WebRootPath, FilePaths.AuthorPath);

            var result = await _userManager.UpdateAsync(author);
            return result.Succeeded ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Image changed") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM> UpdateAsync(AuthorUpdateVM vm)
        {
            var author = await _userManager.Users.FirstOrDefaultAsync();
            if (author == null) throw new NotFoundException("Author");

            author.FirstName = vm.FirstName;
            author.LastName = vm.LastName;
            author.Info = vm.Info;
            author.Description = vm.Description;
            author.Location = vm.Location;
            author.isFreelanceAvailable = vm.isFreelanceAvailable;
            author.PhoneNumber = vm.PhoneNumber;
            author.BirthDate = DateOnlyUtils.GenerateDate(vm.BirthDate.Day, vm.BirthDate.Month, vm.BirthDate.Year);
            var result = await _userManager.UpdateAsync(author);
            return result.Succeeded ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Updated") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM> ChangeEmailAsync(string email)
        {
            var otp = _otpService.GenerateOtp(email);
            await _emailService.SendEmailAsync(email, "Verify Email", $"Your verification code is: {otp} This code will expire in 5 minutes.", false);
            return new ResponseVM { Message = $"Message sent to {email}. Please check and verify your email address." };
        }

        public async Task<ResponseVM> VerifyEmailAsync(string email, int otp)
        {
            var result = _otpService.VerifyOtp(email, otp);
            if (!result) return new ResponseVM { Message = "Otp is not valid.", Result = false };
            var author = await _userManager.Users.FirstOrDefaultAsync();
            author.Email = email;
            author.EmailConfirmed = true;
            var update = await _userManager.UpdateAsync(author);
            return update.Succeeded ? new ResponseVM { Message = "Email changed successfully!" } :
                new ResponseVM { Result = false, Message = update.Errors.FirstOrDefault().Description };
        }

        public async Task<ResponseVM> ChangePasswordAsync(ChangePasswordVM vm, string authorId, string currentPassword)
        {
            var author = await _userManager.FindByIdAsync(authorId);
            if (author == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("user") };
            var result = await _userManager.ChangePasswordAsync(author, currentPassword, vm.NewPassword);
            return result.Succeeded ? new ResponseVM { Message = "Password changed successfully!." } : new ResponseVM { Message = result.Errors.First().Description, Result = false };

        }

        public async Task<ResponseVM> CheckPasswordAsync(string authorId, string currentPaswrod)
        {
            var author = await _userManager.FindByIdAsync(authorId);
            if (author == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("user") };
            var result = await _userManager.CheckPasswordAsync(author, currentPaswrod);
            return result ? new ResponseVM { Message = "Type new password." } : new ResponseVM { Message = "Password is not correct", Result = false };
        }
    }
}

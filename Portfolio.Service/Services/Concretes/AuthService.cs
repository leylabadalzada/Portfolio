using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Portfolio.Core.Constants;
using Portfolio.Core.Models;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Auth;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Concretes
{
    public class AuthService : IAuthService
    {
        readonly SignInManager<Author> _signInManager;
        readonly UserManager<Author> _userManager;
        readonly IEmailService _emailService;
        readonly IHttpContextAccessor _acc;
        public AuthService(SignInManager<Author> signInManager, UserManager<Author> userManager, IEmailService emailService, IHttpContextAccessor acc)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
            _acc = acc;
        }

        public async Task<ResponseVM> LoginAsync(LoginVM vm)
        {
            var response = new ResponseVM { Result = false };
            var user = await _userManager.FindByNameAsync(vm.Username);
            //user yoxlamasi elemirem.
            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, true, true);
            response.Result = result.Succeeded;
            return response;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<ResponseVM> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return new ResponseVM() { Result = false, Message = ResponseMessage.NotFoundMessage("user") };
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink =
     $"{_acc.HttpContext.Request.Scheme}://{_acc.HttpContext.Request.Host}/Admin/Auth/ResetPassword?email={Uri.EscapeDataString(user.Email)}&token={Uri.EscapeDataString(token)}";
            await _emailService.SendEmailAsync(email, "Reset Password", $"Please click on following link to update your password: {resetLink}", false);
            return new ResponseVM { Message = $"Message sent to {email}. Please check your email address." };
        }

        public async Task<ResponseVM> ResetPasswordAsync(ResetPasswordVM vm)
        {
            var user = await _userManager.FindByEmailAsync(vm.Email);

            if (user == null)
            {
                return new ResponseVM
                {
                    Result = false,
                    Message = ResponseMessage.NotFoundMessage("user")
                };
            }

            var result = await _userManager.ResetPasswordAsync(
                user,
                vm.Token,
                vm.NewPassword
            );

            if (!result.Succeeded)
            {
                return new ResponseVM
                {
                    Result = false,
                    Message = string.Join(", ", result.Errors.Select(x => x.Description))
                };
            }

            return new ResponseVM
            {
                Result = true,
                Message = "Password successfully changed."
            };
        }
    }
}

namespace Portfolio.Service.Services.Abstractions
{
    public interface IOtpService
    {
        string GenerateOtp(string email);
        bool VerifyOtp(string email, int otp);
    }
}

using Microsoft.Extensions.Caching.Memory;
using Portfolio.Service.Services.Abstractions;
using System.Security.Cryptography;

namespace Portfolio.Service.Services.Concretes
{
    public class OtpService : IOtpService
    {
        readonly IMemoryCache _cache;

        public OtpService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public string GenerateOtp(string email)
        {
            var otp = RandomNumberGenerator.GetInt32(0, 1_000_000).ToString("D6");
            _cache.Set(email, otp, TimeSpan.FromMinutes(5));
            return otp;
        }

        public bool VerifyOtp(string email, int otp)
        {
            if (_cache.TryGetValue(email, out string? cacheOtp))
            {
                if (cacheOtp == otp.ToString("D6"))
                {
                    _cache.Remove(email);
                    return true;
                }
            }

            return false;
        }
    }
}

using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.Services.Concretes;

namespace Portfolio.Web
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IResumeService, ResumeService>();
            services.AddScoped<ISpecialityService, SpecialityService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();

            return services;
        }
    }
}

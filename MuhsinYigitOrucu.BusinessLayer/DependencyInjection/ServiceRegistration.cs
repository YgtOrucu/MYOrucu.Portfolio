using Microsoft.Extensions.DependencyInjection;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.BusinessLayer.Concrete;

namespace MuhsinYigitOrucu.BusinessLayer.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
        {

            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IFileService, FileManager>();

            services.AddScoped<IExperienceService, ExperienceManager>();

            services.AddScoped<ISkillsService, SkillsManager>();

            services.AddScoped<IProjectService, ProjectManager>();

            services.AddScoped<IProjectDetailsService, ProjectDetailsManager>();

            services.AddScoped<IMessageService, MessageManager>();

            services.AddScoped<IAIService, OpenAIService>();

            services.AddScoped<IMailService, MailManager>();

            return services;
        }
    }
}

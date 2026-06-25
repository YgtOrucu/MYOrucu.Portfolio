using Microsoft.Extensions.DependencyInjection;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.EntityFramework;

namespace MuhsinYigitOrucu.DataAccessLayer.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services)
        {

            services.AddScoped<IAboutDal, EfAboutDal>();

            services.AddScoped<IExperienceDal, EfExperienceDal>();

            services.AddScoped<ISkillsDal, EfSkillsDal>();

            services.AddScoped<IProjectDal, EfProjectDal>();

            services.AddScoped<IProjectDetailsDal, EfProjectDetailsDal>();

            services.AddScoped<IMessageDal, EfMessageDal>();

            return services;
        }
    }
}

using Student.Application.Interfaces;
using Student.Application.Services;
using Student.Domain.Interfaces.Repositories;
using Student.Infrastructure.Repositories;


namespace Student.Api.Extensions
{
    public static class ModuleCollectionExtension
    {
        public static IServiceCollection AddCoreModules(this IServiceCollection services)
        {
            // Services use cases
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }

        public static IServiceCollection AddInfrastructureModules(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();

            return services;
        }
    }
}
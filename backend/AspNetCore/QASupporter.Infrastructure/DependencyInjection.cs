using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QASupporter.Application.Configuration.ApplicationSettings;
using QASupporter.Application.Configuration.Database;
using QASupporter.Application.Configuration.Interfaces;
using QASupporter.Infrastructure.Database;
using QASupporter.Infrastructure.Services;

namespace QASupporter.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<QaSupporterSettings>(configuration.GetSection("QaSupporterSettings"));
            services.Configure<ReadmeSettings>(configuration.GetSection("BuildNote"));
            services.AddDbContext<DBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IDbf2SqlMappingDapperRepository, Dbf2SqlMappingDapperRepository>();
            services.AddScoped<IUserDapperRepository, UserDapperRepository>();
            services.AddScoped<IDbf2SqlMappingRepository, Dbf2SqlMappingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IImageResizerService, ImageResizerService>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IFileSystemService, FileSystemService>();

            return services;
        }
    }
}

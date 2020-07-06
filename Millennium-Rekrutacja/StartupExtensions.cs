using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Millennium_Rekrutacja.BusinessLogic;
using Millennium_Rekrutacja.BusinessLogic.Interface;
using Millennium_Rekrutacja.Common.DbConenction;
using Millennium_Rekrutacja.Repository;
using Millennium_Rekrutacja.Repository.Interface;

namespace Millennium_Rekrutacja
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(Assembly.GetExecutingAssembly());
            });

            var mapper = mappingConfig.CreateMapper();
            return services.AddSingleton(mapper);
        }
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<IArticleRepository, ArticleRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IArticleAddBusinessLogic, ArticleAddBusinessLogic>()
                .AddScoped<IArticleDeleteBusinessLogic, ArticleDeleteBusinessLogic>()
                .AddScoped<IArticleGetByIdBusinessLogic, ArticleGetByIdBusinessLogic>()
                .AddScoped<IArticleUpdateBusinessLogic, ArticleUpdateBusinessLogic>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<RekrutacjaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        public static void DatabaseHandling(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<RekrutacjaDbContext>())
                {
                    context.Database.Migrate();
                }
            }
            
        }
    }
}

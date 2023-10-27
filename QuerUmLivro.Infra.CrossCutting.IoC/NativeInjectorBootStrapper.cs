using Microsoft.Extensions.DependencyInjection;
using QuerUmLivro.Application.AppService;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Interfaces.Services;
using QuerUmLivro.Domain.Services;
using QuerUmLivro.Infra.Data.Context;
using QuerUmLivro.Infra.Data.Repositories;

namespace QuerUmLivro.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            #region AppService

            services.AddScoped<ILivroAppService, LivroAppService>();

            #endregion

            #region Domain            

            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IInteresseService, InteresseService>();
            #endregion

            #region Data
            services.AddScoped(typeof(IRepositoryBase<>), typeof(EFRepository<>));

            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IInteresseRepository, InteresseRepository>();
            
            services.AddScoped<ApplicationDbContext>();
            #endregion


        }
    }
}
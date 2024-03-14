using Microsoft.Extensions.DependencyInjection;
using QuerUmLivro.Application.AppService;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Application.Notificadores;
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
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IInteresseAppService, InteresseAppService>();
            
            services.AddScoped<INotificador, Mensageria>();

            #endregion

            #region Domain            

            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IInteresseService, InteresseService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            #endregion

            #region Data
            services.AddScoped(typeof(IRepositoryBase<>), typeof(EFRepository<>));

            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IInteresseRepository, InteresseRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            
            services.AddScoped<ApplicationDbContext>();
            #endregion


        }
    }
}
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using QuerUmLivro.Application.DTOs.Livro;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // DTOs
            CreateMap<Livro, LivroDto>().ReverseMap();            
            CreateMap<Livro, AlteraLivroDto>().ReverseMap();           
          
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfig));
        }
    }
}

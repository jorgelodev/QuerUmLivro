using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using QuerUmLivro.Domain.DTOs;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // DTOs
            CreateMap<LivroDTO, Livro>().ReverseMap();            
          
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfig));
        }
    }
}

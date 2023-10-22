using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using QuerUmLivro.Application.DTOs.Livro;
using QuerUmLivro.Application.ViewModels.Livro;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Infra.CrossCuttin.Mapper
{    public class NativeMapperBootStrapper : Profile
    {
        public NativeMapperBootStrapper()
        {
            // ViewModels x DTOs
            CreateMap<LivroViewModel, LivroDto>().ReverseMap();

            // Entities x DTOs 
            CreateMap<Livro, LivroDto>().ReverseMap();
            CreateMap<Livro, AlteraLivroDto>().ReverseMap();

        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NativeMapperBootStrapper));
        }
    }
}
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using QuerUmLivro.Application.DTOs.Interesse;
using QuerUmLivro.Application.DTOs.Livro;
using QuerUmLivro.Application.ViewModels.Interesse;
using QuerUmLivro.Application.ViewModels.Livro;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Infra.CrossCuttin.Mapper
{    public class NativeMapperBootStrapper : Profile
    {
        public NativeMapperBootStrapper()
        {
            // ViewModels x DTOs
            CreateMap<LivroViewModel, LivroDto>().ReverseMap();
            CreateMap<AlteraLivroViewModel, AlteraLivroDto>().ReverseMap();
            CreateMap<CadastraLivroViewModel, CadastraLivroDto>().ReverseMap();
            CreateMap<InteresseViewModel, InteresseDto>().ReverseMap();

            // Entities x DTOs 
            CreateMap<Livro, LivroDto>().ReverseMap();
            CreateMap<Livro, AlteraLivroDto>().ReverseMap();
            CreateMap<Livro, CadastraLivroDto>().ReverseMap();
            CreateMap<Interesse, InteresseDto>().ReverseMap();

        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NativeMapperBootStrapper));
        }
    }
}
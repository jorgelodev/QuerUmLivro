using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using QuerUmLivro.Application.DTOs.Interesse;
using QuerUmLivro.Application.DTOs.Livro;
using QuerUmLivro.Application.ViewModels.Interesse;
using QuerUmLivro.Application.ViewModels.Livro;
using QuerUmLivro.Application.ViewModels.Usuario;
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
            CreateMap<LivroComInteressesDto, LivroComInteressesViewModel>().ReverseMap();
            CreateMap<AprovarInteresseDto, AprovarInteresseViewModel>().ReverseMap();            

            CreateMap<InteresseViewModel, InteresseDto>().ReverseMap();
            CreateMap<ManifestarInteresseViewModel, InteresseDto>().ReverseMap();

            CreateMap<UsuarioViewModel, UsuarioDto>().ReverseMap();
            CreateMap<AlteraUsuarioViewModel, AlteraUsuarioDto>().ReverseMap();
            CreateMap<CadastraUsuarioViewModel, CadastraUsuarioDto>().ReverseMap();

            // Entities x DTOs 
            CreateMap<Livro, LivroDto>().ReverseMap();
            CreateMap<Livro, AlteraLivroDto>().ReverseMap();
            CreateMap<Livro, CadastraLivroDto>().ReverseMap();
            CreateMap<Livro, LivroComInteressesDto>().ReverseMap();

            CreateMap<Interesse, InteresseDto>().ReverseMap();
            CreateMap<Interesse, AprovarInteresseDto>().ReverseMap();

            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Usuario, AlteraUsuarioDto>().ReverseMap();
            CreateMap<Usuario, CadastraUsuarioDto>().ReverseMap();

        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NativeMapperBootStrapper));
        }
    }
}
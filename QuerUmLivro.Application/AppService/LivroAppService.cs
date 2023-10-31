using AutoMapper;
using QuerUmLivro.Application.DTOs.Livro;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Services;

namespace QuerUmLivro.Application.AppService
{
    public class LivroAppService : ILivroAppService
    {
        private readonly ILivroService _livroService;
        private readonly IMapper _mapper;

        public LivroAppService(
            ILivroService livroService,           
            IMapper mapper)
        {   
            _livroService = livroService;
            _mapper = mapper;
        }

        public AlteraLivroDto Alterar(AlteraLivroDto alteraLivroDto)
        {
            var livro = _mapper.Map<Livro>(alteraLivroDto);
            
            return _mapper.Map<AlteraLivroDto>(_livroService.Alterar(livro));
        }

        public LivroDto Cadastrar(CadastraLivroDto livroDto)
        {
            var livro = _mapper.Map<Livro>(livroDto);            

            return _mapper.Map<LivroDto>(_livroService.Cadastrar(livro));
        }

        public LivroDto Deletar(int id)
        {
            var livro = _livroService.Deletar(id);

            return _mapper.Map<LivroDto>(livro);
        }

        public LivroDto ObterPorId(int id)
        {
            var livro = _livroService.ObterPorId(id);

            return _mapper.Map<LivroDto>(livro);
        }

        public ICollection<LivroDto> ObterPorDoador(int idUsuario)
        {
            var livros = _livroService.ObterPorDoador(idUsuario);

            return _mapper.Map<ICollection<LivroDto>>(livros);
        }

        public ICollection<LivroDto> Disponiveis()
        {
            var livros = _livroService.Disponiveis();

            return _mapper.Map<ICollection<LivroDto>>(livros);
        }
        public ICollection<LivroComInteressesDto> ObterComInteresse(int idDoador)
        {
            var livros = _livroService
                .ObterComInteresse(idDoador)
                .Where(l => l.Disponivel).ToList();
            var retorno = _mapper.Map<List<LivroComInteressesDto>>(livros);
            return retorno;
        }
    }
}

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

        public LivroAppService(ILivroService livroService, IMapper mapper)
        {
            _livroService = livroService;
            _mapper = mapper;
        }

        public AlteraLivroDto Alterar(AlteraLivroDto alteraLivroDto)
        {
            var livro = _mapper.Map<Livro>(alteraLivroDto);
            
            return _mapper.Map<AlteraLivroDto>(_livroService.Alterar(livro));
        }

        public LivroDto Cadastrar(LivroDto livroDto)
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

        public IList<LivroDto> ObterTodos()
        {
            var livros = _livroService.ObterTodos();

            return _mapper.Map<List<LivroDto>>(livros);
        }
    }
}

﻿using AutoMapper;
using QuerUmLivro.Application.DTOs.Interesse;
using QuerUmLivro.Application.DTOs.Livro;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Services;

namespace QuerUmLivro.Application.AppService
{
    public class LivroAppService : ILivroAppService
    {
        private readonly ILivroService _livroService;
        private readonly IInteresseService _interesseService;
        private readonly IMapper _mapper;

        public LivroAppService(
            ILivroService livroService, 
            IInteresseService interesseService, 
            IMapper mapper)
        {
            _interesseService = interesseService;
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

        public IList<LivroDto> ObterPorDoador(int idUsuario)
        {
            var livros = _livroService.ObterPorDoador(idUsuario);

            return _mapper.Map<List<LivroDto>>(livros);
        }

        public IList<LivroDto> Disponiveis()
        {
            var livros = _livroService.Disponiveis();

            return _mapper.Map<List<LivroDto>>(livros);
        }

        public InteresseDto ManifestarInteresse(InteresseDto interesse)
        {
            var interesseManifestado = _interesseService.ManifestarInteresse(_mapper.Map<Interesse>(interesse));

            return _mapper.Map<InteresseDto>(interesseManifestado) ;
        }
    }
}
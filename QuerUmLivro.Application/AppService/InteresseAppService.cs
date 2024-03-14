
using AutoMapper;
using QuerUmLivro.Application.DTOs.Interesse;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Application.Notificadores;
using QuerUmLivro.Application.ViewModels.Interesse;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Services;
using System.Collections.Specialized;

namespace QuerUmLivro.Application.AppService
{
    public class InteresseAppService : IInteresseAppService
    {

        private readonly IInteresseService _interesseService;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;
        private readonly IUsuarioService _usuarioService;


        public InteresseAppService(
            IInteresseService interesseService,
            IMapper mapper,
            INotificador notificador,
            IUsuarioService usuarioService)
        {
            _interesseService = interesseService;
            _mapper = mapper;
            _notificador = notificador;
            _usuarioService = usuarioService;
        }

        public AprovarInteresseDto AprovarInteresse(AprovarInteresseDto aprovarInteresseDto)
        {
            var interesseAprovado = _interesseService.AprovarInteresse(_mapper.Map<Interesse>(aprovarInteresseDto), aprovarInteresseDto.DoadorId);
            
            return _mapper.Map<AprovarInteresseDto>(interesseAprovado);
        }

        public InteresseDto ManifestarInteresse(InteresseDto interesse)
        {
            var interesseManifestado = _interesseService.ManifestarInteresse(_mapper.Map<Interesse>(interesse));

            if (interesseManifestado.ValidationResult.IsValid)
            {
                interesseManifestado.Livro.Doador = _usuarioService.ObterPorId(interesseManifestado.Livro.DoadorId);
                _notificador.NotificaManifestarInteresse(interesseManifestado);
            }

            return _mapper.Map<InteresseDto>(interesseManifestado);
        }
    }
}

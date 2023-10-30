
using AutoMapper;
using QuerUmLivro.Application.DTOs.Interesse;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Application.ViewModels.Interesse;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Services;

namespace QuerUmLivro.Application.AppService
{
    public class InteresseAppService : IInteresseAppService
    {

        private readonly IInteresseService _interesseService;
        private readonly IMapper _mapper;

        public InteresseAppService(
            IInteresseService interesseService,
            IMapper mapper)
        {
            _interesseService = interesseService;
            _mapper = mapper;
        }

        public AprovarInteresseDto AprovarInteresse(AprovarInteresseDto aprovarInteresseDto)
        {
            var interesseAprovado = _interesseService.AprovarInteresse(_mapper.Map<Interesse>(aprovarInteresseDto));
            
            return _mapper.Map<AprovarInteresseDto>(interesseAprovado);
        }

        public InteresseDto ManifestarInteresse(InteresseDto interesse)
        {
            var interesseManifestado = _interesseService.ManifestarInteresse(_mapper.Map<Interesse>(interesse));

            return _mapper.Map<InteresseDto>(interesseManifestado);
        }
    }
}

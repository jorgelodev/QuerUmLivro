using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuerUmLivro.Application.DTOs.Interesse;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Application.ViewModels.Interesse;

namespace QuerUmLivro.API.Controllers
{
    [ApiController]
    [Route("Interesse")]
    public class InteresseController : MainController
    {
        private readonly IInteresseAppService _intresseAppService;
        private readonly IMapper _mapper;

        public InteresseController(IInteresseAppService interesseAppService, IMapper mapper)
        {
            _intresseAppService = interesseAppService;
            _mapper = mapper;
        }

        /// <summary>
        /// Manifestar interesse em um determinado livro.
        /// </summary>
        /// <param name="manifestarInteresseViewModel">ViewModel para manifestar interesse.</param>        
        /// <remarks>
        /// 
        /// Informe o id do livro, id do usuário interessado e justificativa para manifestar o interesse no livro. 
        /// 
        /// </remarks>
        /// <response code="200">Manifestação registrada com sucesso</response>
        /// <response code="400">Manifestação não realizada, é retornado mensagem com o(s) motivo(s).</response>
        [HttpPost]
        public IActionResult ManifestarInteresse(ManifestarInteresseViewModel manifestarInteresseViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var interesseManifestado = _intresseAppService.ManifestarInteresse(_mapper.Map<InteresseDto>(manifestarInteresseViewModel));

            if (!interesseManifestado.ValidationResult.IsValid)
                AdicionarErroProcessamento(interesseManifestado.ValidationResult);

            return CustomResponse();
        }

        /// <summary>
        /// Doador realiza a aprovação do interesse.
        /// </summary>
        /// <param name="aprovaInteresseViewModel">ViewModel para aprovar interesse.</param>        
        /// <remarks>
        /// 
        /// Informe id do interesse e id do doador que está aprovando o interesse. 
        /// 
        /// </remarks>
        /// <response code="200">Aprovação Realizada com sucesso</response>
        /// <response code="400">Aprovação não realizada, é retornado mensagem com o(s) motivo(s).</response>
        [HttpPut]
        public IActionResult AprovarInteresse(AprovarInteresseViewModel aprovaInteresseViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var interesseAprovado = _intresseAppService.AprovarInteresse(_mapper.Map<AprovarInteresseDto>(aprovaInteresseViewModel));

            if (!interesseAprovado.ValidationResult.IsValid)

                AdicionarErroProcessamento(interesseAprovado.ValidationResult);

            return CustomResponse();

        }
    }
}

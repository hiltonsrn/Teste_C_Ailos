using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Handlers.Interfaces;
using Questao5.Infrastructure.Services.Filters;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentoController : ControllerBase
    {
        [HttpPost]
        [Route("operacao")]
        [Idempotent(typeof(CreateMovimentoRequest), typeof(CreateMovimentoResponse))]
        public async Task<ActionResult<CreateMovimentoResponse>> Create([FromQuery] string chave,
                   [FromServices] ICreateMovimentoHandler handler,
                   [FromBody] CreateMovimentoRequest command
               )
        {
            try
            {
                var response = await handler.Handle(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("chave")]
        public async Task<ActionResult<string>> GetChave(int numeroConta,
            [FromServices] IFindContaCorrenteByNumeroHandler handler)
        {
            try
            {
                await handler.Handle(new FindContaCorrenteByNumeroRequest
                {
                    Numero = numeroConta
                });
                var _chave = Guid.NewGuid().ToString();
                return Ok(_chave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
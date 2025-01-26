using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Handlers.Interfaces;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<FindContaCorrenteByNumeroResponse>> GetByNumero(
            [FromServices] IFindContaCorrenteByNumeroHandler handler,
            [FromQuery] FindContaCorrenteByNumeroRequest command
        )
        {
            try
            {
                var result = await handler.Handle(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
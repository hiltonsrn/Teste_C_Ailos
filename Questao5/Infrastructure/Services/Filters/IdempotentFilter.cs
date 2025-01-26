using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using NSubstitute;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Handlers;
using Questao5.Application.Handlers.Interfaces;

namespace Questao5.Infrastructure.Services.Filters
{
    public class IdempotentAttribute : ActionFilterAttribute //, IAuthorizationFilter
    {
        IFindIdempotenciaByIdHandler _handlerFind;
        ICreateIdempontenciaHandler _handlerCreate;

        string idempontencia;
        FindIdempotenciaByIdResponse existente;
        Type _typeRequet;
        Type _typeResponse;
        object _requestValue;
        public IdempotentAttribute(Type typeRequet,
        Type typeResponse)
        {
            _typeRequet = typeRequet;
            _typeResponse = typeResponse;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            idempontencia = context.HttpContext.Request.QueryString.Value.Split("=")[1];
            _handlerFind = context.HttpContext.RequestServices.GetService<IFindIdempotenciaByIdHandler>();
            _requestValue = context.ActionArguments.FirstOrDefault(item => item.Value.GetType() == _typeRequet).Value;

            existente = await _handlerFind.Handle(new FindIdempotenciaByIdRequest { Id = idempontencia });
            if (existente != null)
            {
                if (existente.Requisicao == JsonConvert.SerializeObject(_requestValue))
                {
                    object response = JsonConvert.DeserializeObject(existente.Resultado, _typeResponse);
                    context.Result = new OkObjectResult(response);
                }
            }
            await base.OnActionExecutionAsync(context, next);
        }
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (existente == null)
            {
                var novo = new CreateIdempotenciaRequest
                {
                    Chave_Idempotencia = idempontencia,
                    Requisicao = JsonConvert.SerializeObject(_requestValue),
                    Resultado = JsonConvert.SerializeObject(((Microsoft.AspNetCore.Mvc.ObjectResult)context.Result).Value)
                };
                _handlerCreate = context.HttpContext.RequestServices.GetService<ICreateIdempontenciaHandler>();
                await _handlerCreate.Handle(novo);
            }
            await base.OnResultExecutionAsync(context, next);
        }
    }
}

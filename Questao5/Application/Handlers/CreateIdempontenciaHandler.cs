using Castle.Core.Resource;
using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Handlers.Interfaces;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Application.Handlers
{
    public class CreateIdempontenciaHandler : ICreateIdempontenciaHandler
    {
        IUnitOfWork _unitOfWork;

        public CreateIdempontenciaHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateIdempotenciaResponse> Handle(CreateIdempotenciaRequest request)
        {
            var idempotencia = new Idempotencia
            {
                Chave_Idempotencia = request.Chave_Idempotencia,
                Requisicao = request.Requisicao,
                Resultado = request.Resultado,
            };
            await _unitOfWork.Idempotencias.AddIdempotencia(idempotencia);
            var result = new CreateIdempotenciaResponse
            {
                Chave_Idempotencia = idempotencia.Chave_Idempotencia,
                Requisicao = idempotencia.Requisicao,
                Resultado = idempotencia.Resultado,
            };
            return await Task.FromResult(result);
        }
    }
}

using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Handlers.Interfaces;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Application.Handlers
{
    public class FindIdempotenciaByIdHandler : IFindIdempotenciaByIdHandler
    {
        IUnitOfWork _unitOfWork;

        public FindIdempotenciaByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FindIdempotenciaByIdResponse> Handle(FindIdempotenciaByIdRequest request)
        {
            Idempotencia idempotencia = await _unitOfWork.Idempotencias.GetIdempotencia(request.Id);
            FindIdempotenciaByIdResponse result = null;
            if (idempotencia != null)
            {
                result = new FindIdempotenciaByIdResponse
                {
                    Chave_Idempotencia = idempotencia.Chave_Idempotencia,
                    Requisicao = idempotencia.Requisicao,
                    Resultado = idempotencia.Resultado,
                };
            }
            return await Task.FromResult(result);
        }
    }
}

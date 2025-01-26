using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Handlers.Interfaces
{
    public interface ICreateMovimentoHandler
    {
        Task<CreateMovimentoResponse> Handle(CreateMovimentoRequest request);
    }
}

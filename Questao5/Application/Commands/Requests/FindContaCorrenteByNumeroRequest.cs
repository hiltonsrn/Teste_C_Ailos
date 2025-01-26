using MediatR;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Enumerators;

namespace Questao5.Application.Commands.Requests
{
    public class FindContaCorrenteByNumeroRequest : IRequest<FindContaCorrenteByNumeroResponse>
    {
        public int Numero { get; set; }
    }
}

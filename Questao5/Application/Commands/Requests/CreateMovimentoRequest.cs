using MediatR;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Enumerators;

namespace Questao5.Application.Commands.Requests
{
    public class CreateMovimentoRequest : IRequest<CreateMovimentoResponse>
    {
        public int NumeroConta { get; set; }
        public char TipoMovimento { get; set; }
        public double Valor { get; set; }
    }
}

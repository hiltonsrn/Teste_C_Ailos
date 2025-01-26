using Questao5.Domain.Enumerators;

namespace Questao5.Application.Commands.Responses
{
    public class MovimentoResponse
    {
        public string DataMovimento { get; set; }
        public char TipoMovimento { get; set; }
        public double Valor { get; set; }
    }
}
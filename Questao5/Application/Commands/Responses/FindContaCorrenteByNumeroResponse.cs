using Questao5.Domain.Enumerators;

namespace Questao5.Application.Commands.Responses
{
    public class FindContaCorrenteByNumeroResponse
    {
        public int Numero { get; set; }

        public string Nome { get; set; }

        public int Ativo { get; set; }
        public double Saldo{ get; set; }
        public List<MovimentoResponse> Movimentacao { get; set; }
    }
}

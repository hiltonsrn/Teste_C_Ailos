using Questao5.Application.Commands.Requests;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Repositories;
using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Application.Handlers
{
    public class Validations
    {
        public static async Task<ContaCorrente> ValidaConta(IUnitOfWork _unitOfWork, int numero)
        {
            var conta = await _unitOfWork.ContaCorrentes.GetByNumero(numero);
            if (conta == null)
                throw new Exception("Conta Corrente não econtrada");
            if (conta.Ativo == 0)
                throw new Exception("Conta Inativada");
            return conta;
        }
        public static async Task<ContaCorrente> ValidaMovimento(IUnitOfWork _unitOfWork, CreateMovimentoRequest movimentoRequest)
        {
            var conta = await Validations.ValidaConta(_unitOfWork, movimentoRequest.NumeroConta);
            string tipo = movimentoRequest.TipoMovimento.ToString().ToUpper();
            if (tipo != "C" && tipo != "D")
                throw new Exception("Tipo de movimentação não encontrada");
            if (movimentoRequest.Valor <= 0)
                throw new Exception("Valor não autorizado");
            return conta;
        }
    }
}
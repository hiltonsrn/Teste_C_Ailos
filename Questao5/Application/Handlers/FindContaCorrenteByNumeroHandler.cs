using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Handlers.Interfaces;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Repositories;
using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Application.Handlers
{
    public class FindContaCorrenteByNumeroHandler : IFindContaCorrenteByNumeroHandler
    {
        IUnitOfWork _unitOfWork;

        public FindContaCorrenteByNumeroHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FindContaCorrenteByNumeroResponse> Handle(FindContaCorrenteByNumeroRequest request)
        {
            ContaCorrente conta = await Validations.ValidaConta(_unitOfWork,request.Numero);
            conta.Movimentos = await _unitOfWork.Movimentos.GetByConta(conta.IdContaCorrente);
            FindContaCorrenteByNumeroResponse result = new FindContaCorrenteByNumeroResponse
            {
                Nome = conta.Nome,
                Numero = conta.Numero,
                Ativo = conta.Ativo,
                Movimentacao = conta.Movimentos.Select(mov=> new MovimentoResponse
                {
                    DataMovimento = mov.DataMovimento,
                    TipoMovimento = mov.TipoMovimento,
                    Valor = mov.Valor
                }).ToList(),
            };
            foreach (var movimento in conta.Movimentos)
            {
                result.Saldo += (movimento.TipoMovimento.ToString().ToUpper() == "C" ? movimento.Valor : (movimento.Valor * -1));
            }
            return await Task.FromResult(result);
        }
    }
}

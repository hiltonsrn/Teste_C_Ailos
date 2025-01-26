using Castle.Core.Resource;
using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Handlers.Interfaces;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Application.Handlers
{
    public class CreateMovimentoHandler : ICreateMovimentoHandler
    {
        IUnitOfWork _unitOfWork;

        public CreateMovimentoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateMovimentoResponse> Handle(CreateMovimentoRequest request)
        {
            ContaCorrente conta = await Validations.ValidaMovimento(_unitOfWork, request);
            var movimento = new Movimento
            {
                IdContaCorrente = conta.IdContaCorrente,
                TipoMovimento = request.TipoMovimento,
                Valor = request.Valor,
                DataMovimento = DateTime.Now.ToString()
            };
            await _unitOfWork.Movimentos.AddMovimento(movimento);
            var result = new CreateMovimentoResponse
            {
                DataMovimento = movimento.DataMovimento,
                TipoMovimento = movimento.TipoMovimento,
                Valor = movimento.Valor
            };
            return await Task.FromResult(result);
        }
    }
}

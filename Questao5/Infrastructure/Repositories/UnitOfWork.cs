using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IContaCorrenteRepository ContaCorrentes { get; }

        public IMovimentoRepository Movimentos { get; }

        public IIdempotenciaRepository Idempotencias { get; }

        public UnitOfWork(IContaCorrenteRepository contaCorrentes,
            IMovimentoRepository movimentos,
            IIdempotenciaRepository idempotencias)
        {
            ContaCorrentes = contaCorrentes;
            Movimentos = movimentos;
            Idempotencias = idempotencias;
        }
    }
}

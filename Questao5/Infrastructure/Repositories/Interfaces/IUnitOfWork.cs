namespace Questao5.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IContaCorrenteRepository ContaCorrentes { get; }
        IMovimentoRepository Movimentos { get; }
        IIdempotenciaRepository Idempotencias { get; }
    }
}



using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Repositories.Interfaces
{
    public interface IMovimentoRepository
    {
        Task<Movimento> AddMovimento(Movimento movimento);
        Task<List<Movimento>> GetByConta(string contaId);
    }
}

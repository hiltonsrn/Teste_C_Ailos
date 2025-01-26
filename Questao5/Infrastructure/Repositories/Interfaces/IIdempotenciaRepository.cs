

using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Repositories.Interfaces
{
    public interface IIdempotenciaRepository
    {
        Task<Idempotencia> AddIdempotencia(Idempotencia idempotencia);
        Task<Idempotencia> GetIdempotencia(string id);
    }
}

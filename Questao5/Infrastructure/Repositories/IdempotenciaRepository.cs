using Questao5.Domain.Entities;
using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Infrastructure.Repositories
{
    public class IdempotenciaRepository : BaseRepository<Idempotencia>, IIdempotenciaRepository
    {
        public IdempotenciaRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<Idempotencia> AddIdempotencia(Idempotencia idempotencia)
        {
            Conectar();
            var result = await Add(idempotencia);
            Desconectar();
            return idempotencia;
        }

        public async Task<Idempotencia> GetIdempotencia(string id)
        {
            Conectar();
            var result = await GetOneByCol("Chave_Idempotencia", $"'{id}'");
            Desconectar();
            return result;
        }
    }
}

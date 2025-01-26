using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Infrastructure.Repositories
{
    public class ContaCorrenteRepository : BaseRepository<ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<ContaCorrente> GetByNumero(int numero)
        {
            Conectar();
            var result = await GetOneByCol("Numero",$"{numero}");
            Desconectar();
            return result;
        }
    }
}

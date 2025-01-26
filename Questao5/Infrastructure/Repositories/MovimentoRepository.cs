using Questao5.Domain.Entities;
using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Infrastructure.Repositories
{
    public class MovimentoRepository : BaseRepository<Movimento>, IMovimentoRepository
    {
        public MovimentoRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<List<Movimento>> GetByConta(string contaId)
        {
            Conectar();
            var result = await GetAllByCol("idcontacorrente", $"'{contaId}'");
            Desconectar();
            return result.ToList();
        }
        public async Task<Movimento> AddMovimento(Movimento movimento)
        {
            Conectar();
            var result = await Add(movimento);
            Desconectar();
            return result;
        }
    }
}

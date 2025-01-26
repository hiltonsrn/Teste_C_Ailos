using Questao5.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao5.Tests.Mock
{
    internal class MockUnitOfWork : IUnitOfWork
    {
        public IContaCorrenteRepository ContaCorrentes{ get; }

        public IMovimentoRepository Movimentos { get; }

        public IIdempotenciaRepository Idempotencias { get; }
    }
}

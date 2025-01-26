using Questao5.Domain.Entities;
using Questao5.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Questao5.Tests.Mock
{
    internal class MockContaCorrenteRepository : IContaCorrenteRepository
    {
        public Task<ContaCorrente> GetByNumero(int numero)
        {
            if (numero == 0)
                throw new Exception("Conta Corrente não econtrada");
            if (numero == -1)
                throw new Exception("Conta Corrente Inativada");
            return Task.FromResult(new ContaCorrente
            {
                Numero = numero
            });
        }
    }
}

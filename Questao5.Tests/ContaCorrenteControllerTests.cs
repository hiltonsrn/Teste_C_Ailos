using Questao5.Application.Handlers;
using Questao5.Infrastructure.Services.Controllers;
using Questao5.Tests.Mock;

namespace Questao5.Tests
{
    public class ContaCorrenteControllerTests
    {
        ContaCorrenteController _controller;
        FindContaCorrenteByNumeroHandler _handler;
        [SetUp]
        public void Setup()
        {
            _controller = new ContaCorrenteController();
            _handler = new FindContaCorrenteByNumeroHandler(new MockUnitOfWork());
        }

        [Test]
        public async Task ContaCorrenteInexistene()
        {
            try
            {
                await _controller.GetByNumero(_handler, new Application.Commands.Requests.FindContaCorrenteByNumeroRequest
                {
                    Numero = 0
                });
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Conta Corrente não econtrada", ex.Message);
            }
        }
        [Test]
        public async Task ContaCorrenteInativa()
        {
            try
            {
                await _controller.GetByNumero(_handler, new Application.Commands.Requests.FindContaCorrenteByNumeroRequest
                {
                    Numero = 0
                });
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Conta Corrente Inativada", ex.Message);
            }
        }
    }
}
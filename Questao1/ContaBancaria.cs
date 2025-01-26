using System.Globalization;

namespace Questao1
{
    class ContaBancaria
    {
        public int Numero { get; set; }
        public string Titular { get; set; }
        public double Saldo { get; set; }
        private const double _taxa = 3.5;
        private void IniciarConta(int _numero, string _titular, double _saldo)
        {
            Numero = _numero;
            Titular = _titular;
            Saldo = _saldo;
        }
        public ContaBancaria(int _numero,
                            string _titular,
                            double _saldo)
        {
            IniciarConta(_numero, _titular, _saldo);
        }
        public ContaBancaria(int _numero,
                            string _titular)
        {
            IniciarConta(_numero, _titular, 0);
        }
        public void Saque(double valor)
        {
            Saldo -= (valor + _taxa);
        }
        public void Deposito(double valor)
        {
            Saldo += valor;
        }
    }
}

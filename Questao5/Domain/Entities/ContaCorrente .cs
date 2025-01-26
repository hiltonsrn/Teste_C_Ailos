using FluentAssertions.Equivalency;
using Questao5.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace Questao5.Domain.Entities
{
    public class ContaCorrente
    {
        [Key]
        public string IdContaCorrente { get; set; }

        public int Numero { get; set; }

        public string Nome { get; set; }

        public int Ativo { get; set; }
        public List<Movimento> Movimentos { get; set; } = new List<Movimento>();
    }
}

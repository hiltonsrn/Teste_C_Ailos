using Questao5.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        [Key]
        public string IdMovimento { get; set; }
        public string IdContaCorrente { get; set; }
        public string DataMovimento { get; set; }
        public char TipoMovimento { get; set; }
        public double Valor { get; set; }

    }
}

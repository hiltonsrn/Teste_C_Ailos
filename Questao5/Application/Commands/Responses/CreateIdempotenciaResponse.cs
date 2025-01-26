using Questao5.Domain.Enumerators;

namespace Questao5.Application.Commands.Responses
{
    public class CreateIdempotenciaResponse
    {
        public string Chave_Idempotencia { get; set; }
        public string Requisicao { get; set; }
        public string Resultado { get; set; }
    }
}

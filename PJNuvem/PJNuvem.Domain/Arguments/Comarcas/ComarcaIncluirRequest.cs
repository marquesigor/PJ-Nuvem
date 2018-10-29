using PJNuvem.Domain.Interfaces.Arguments;

namespace PJNuvem.Domain.Arguments.Comarcas
{
    public class ComarcaIncluirRequest : IRequest
    {
        public string Descricao { get; set; }
    }
}

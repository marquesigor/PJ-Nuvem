using PJNuvem.Domain.Interfaces.Arguments;

namespace PJNuvem.Domain.Arguments.Perfis
{
    public class PerfilIncluirRequest : IRequest
    {
        public string Descricao { get; set; }
    }
}

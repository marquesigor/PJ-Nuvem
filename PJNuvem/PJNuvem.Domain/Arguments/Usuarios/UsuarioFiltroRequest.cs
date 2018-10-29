using PJNuvem.Domain.Interfaces.Arguments;

namespace PJNuvem.Domain.Arguments.Usuarios
{
    public class UsuarioFiltroRequest : IRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}

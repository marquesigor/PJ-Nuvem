using PJNuvem.Domain.Interfaces.Arguments;

namespace PJNuvem.Domain.Arguments.Login
{
    public class UsuarioLoginRequest : IRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

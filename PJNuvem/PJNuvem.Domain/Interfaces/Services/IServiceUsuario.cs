using PJNuvem.Domain.Arguments.Login;
using PJNuvem.Domain.Arguments.Usuarios;
using PJNuvem.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace PJNuvem.Domain.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase
    {
        UsuarioLoginResponse Autenticar(UsuarioLoginRequest request);
        IEnumerable<UsuarioResponse> ListarFiltrado(UsuarioFiltroRequest request);
    }
}

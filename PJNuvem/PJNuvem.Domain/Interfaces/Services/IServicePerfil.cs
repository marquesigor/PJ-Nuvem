using PJNuvem.Domain.Arguments.Perfis;
using PJNuvem.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace PJNuvem.Domain.Interfaces.Services
{
    public interface IServicePerfil : IServiceBase
    {
        IEnumerable<PerfilResponse> ListarFiltrado(string descricao);
    }
}

using PJNuvem.Domain.Arguments.Comarcas;
using PJNuvem.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace PJNuvem.Domain.Interfaces.Services
{
    public interface IServiceComarca : IServiceBase
    {
        IEnumerable<ComarcaResponse> ListarFiltrado(string descricao);
    }
}

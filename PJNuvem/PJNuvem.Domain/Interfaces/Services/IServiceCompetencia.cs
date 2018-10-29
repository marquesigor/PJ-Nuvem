using PJNuvem.Domain.Arguments.Competencias;
using PJNuvem.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace PJNuvem.Domain.Interfaces.Services
{
    public interface IServiceCompetencia : IServiceBase
    {
        IEnumerable<CompetenciaResponse> ListarFiltrado(string descricao);
    }
}

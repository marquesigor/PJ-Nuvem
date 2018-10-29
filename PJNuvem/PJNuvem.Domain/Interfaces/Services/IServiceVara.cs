using PJNuvem.Domain.Arguments.Varas;
using PJNuvem.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace PJNuvem.Domain.Interfaces.Services
{
    public interface IServiceVara : IServiceBase
    {
        IEnumerable<VaraResponse> ListarFiltrado(string filtro);
        List<RetornaVarasQueTenhamAsCompetenciasDaClasseProcessual> RetornaVarasQueAtendamAsCompetencias(Guid classeProcessualId, Guid comarcaId);
    }
}

using PJNuvem.Domain.Arguments.VarasCompetencias;
using PJNuvem.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace PJNuvem.Domain.Interfaces.Services
{
    public interface IServiceVaraCompetencia : IServiceBase
    {
        IEnumerable<VaraCompetenciaResponse> ListarFiltrado(string filtro);
        void AtualizaQuantidadeDeProcessos(Guid id);
    }
}

using PJNuvem.Domain.Arguments.ClassesProcessuaisCompetencias;
using PJNuvem.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace PJNuvem.Domain.Interfaces.Services
{
    public interface IServiceClasseProcessualCompetencia : IServiceBase
    {
        IEnumerable<ClasseProcessualCompetenciaResponse> ListarFiltrado(string filtro);
    }
}

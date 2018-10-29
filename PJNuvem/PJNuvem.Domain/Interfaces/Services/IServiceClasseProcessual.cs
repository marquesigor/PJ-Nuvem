using PJNuvem.Domain.Arguments.ClassesProcessuais;
using PJNuvem.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace PJNuvem.Domain.Interfaces.Services
{
    public interface IServiceClasseProcessual : IServiceBase
    {
        IEnumerable<ClasseProcessualResponse> ListarFiltrado(string descricao);
    }
}
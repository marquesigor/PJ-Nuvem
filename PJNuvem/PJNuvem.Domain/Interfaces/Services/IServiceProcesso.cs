using PJNuvem.Domain.Arguments.Processos;
using PJNuvem.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace PJNuvem.Domain.Interfaces.Services
{
    public interface IServiceProcesso : IServiceBase
    {
        IEnumerable<ProcessoResponse> ListarFiltrado(string filtro);
        void PreencheVaraId(Guid id);
    }
}


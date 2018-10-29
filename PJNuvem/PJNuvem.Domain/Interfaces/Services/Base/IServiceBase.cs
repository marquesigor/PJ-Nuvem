using PJNuvem.Domain.Interfaces.Arguments;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;

namespace PJNuvem.Domain.Interfaces.Services.Base
{
    public interface IServiceBase : INotifiable
    {
        IEnumerable<IResponse> Listar();
        IResponse Adicionar(IRequest request);
        IResponse Alterar(IRequest request);
        IResponse Excluir(Guid id);
    }
}

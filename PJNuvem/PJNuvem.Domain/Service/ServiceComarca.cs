using PJNuvem.Domain.Arguments.Base;
using PJNuvem.Domain.Arguments.Comarcas;
using PJNuvem.Domain.Interfaces.Arguments;
using PJNuvem.Domain.Interfaces.Repositories;
using PJNuvem.Domain.Interfaces.Services;
using PJNuvem.Domain.Model;
using PJNuvem.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PJNuvem.Domain.Service
{
    public class ServiceComarca : Notifiable, IServiceComarca
    {
        private readonly IRepositoryComarca _repositoryComarca;
        public ServiceComarca() { }
        public ServiceComarca(IRepositoryComarca repositoryComarca) => _repositoryComarca = repositoryComarca;
        private Comarca _comarca;

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Incluir", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("ComarcaIncluirRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (ComarcaIncluirRequest)request;
            _comarca = new Comarca();
            _comarca.Incluir(requestClasse.Descricao);
            AddNotifications(_comarca);
            if (IsInvalid()) return null;
            _comarca = _repositoryComarca.Adicionar(_comarca);

            return (ResponseBase)_comarca.Id;
        }

        public IResponse Alterar(IRequest request)
        {
            if (request is null) AddNotification("Alterar", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("ComarcaAlterarRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (ComarcaAlterarRequest)request;
            _comarca = _repositoryComarca.ObterPorId(requestClasse.Id);
            if (_comarca == null)
            {
                AddNotification("Comarca", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _comarca.Alterar(requestClasse.Id, requestClasse.Descricao);
            _comarca = _repositoryComarca.Editar(_comarca);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IResponse Excluir(Guid id)
        {
            _comarca = _repositoryComarca.ObterPorId(id);
            if (_comarca == null)
            {
                AddNotification("Comarca", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryComarca.Remover(_comarca);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }


        public IEnumerable<IResponse> Listar()
        {
            return _repositoryComarca.ListarOrdenadosPor(item => item.Descricao).ToList().Select(Comarca => (ComarcaResponse)Comarca);

        }

        public IEnumerable<ComarcaResponse> ListarFiltrado(string descricao)
        {
            return _repositoryComarca.ListarPor(item => item.Descricao.Contains(descricao)).ToList().Select(Comarca => (ComarcaResponse)Comarca);
        }
    }
}
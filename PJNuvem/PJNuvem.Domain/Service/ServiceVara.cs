using PJNuvem.Domain.Arguments.Base;
using PJNuvem.Domain.Arguments.Varas;
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
    public class ServiceVara : Notifiable, IServiceVara
    {
        private readonly IRepositoryVara _repositoryVara;
        public ServiceVara() { }
        public ServiceVara(IRepositoryVara repositoryVara) => _repositoryVara = repositoryVara;
        private Vara _vara;

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Incluir", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("VaraIncluirRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (VaraIncluirRequest)request;
            _vara = new Vara();
            _vara.Incluir(requestClasse.ComarcaId,requestClasse.Descricao);
            AddNotifications(_vara);
            if (IsInvalid()) return null;
            _vara = _repositoryVara.Adicionar(_vara);

            return (ResponseBase)_vara.Id;
        }

        public IResponse Alterar(IRequest request)
        {
            if (request is null) AddNotification("Alterar", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("VaraAlterarRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (VaraAlterarRequest)request;
            _vara = _repositoryVara.ObterPorId(requestClasse.Id);
            if (_vara == null)
            {
                AddNotification("Vara", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _vara.Alterar(requestClasse.Id,requestClasse.ComarcaId, requestClasse.Descricao);
            _vara = _repositoryVara.EditarRemovendoProperties(_vara);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IResponse Excluir(Guid id)
        {
            _vara = _repositoryVara.ObterPorId(id);
            if (_vara == null)
            {
                AddNotification("Vara", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryVara.Remover(_vara);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public List<RetornaVarasQueTenhamAsCompetenciasDaClasseProcessual> RetornaVarasQueAtendamAsCompetencias(Guid classeProcessualId, Guid comarcaId)
        {
            return _repositoryVara.ExecutaProcedure<RetornaVarasQueTenhamAsCompetenciasDaClasseProcessual>($"RetornaVarasQueTenhamAsCompetenciasDaClasseProcessual '{classeProcessualId}', '{comarcaId}'").ToList(); ;
        }

        public IEnumerable<IResponse> Listar()
        {
            return _repositoryVara.ListarOrdenadosPor(item => item.Descricao,true, include => include.Comarca).ToList().Select(vara => (VaraResponse)vara);

        }

        public IEnumerable<VaraResponse> ListarFiltrado(string filtro)
        {
            return _repositoryVara.ListarPor(item => item.Descricao.Contains(filtro) || item.Comarca.Descricao.Contains(filtro), include => include.Comarca).ToList().Select(Vara => (VaraResponse)Vara);
        }
    }
}
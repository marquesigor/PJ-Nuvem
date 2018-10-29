using PJNuvem.Domain.Arguments.Base;
using PJNuvem.Domain.Arguments.Competencias;
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
    public class ServiceCompetencia : Notifiable, IServiceCompetencia
    {
        private readonly IRepositoryCompetencia _repositoryCompetencia;
        public ServiceCompetencia() { }
        public ServiceCompetencia(IRepositoryCompetencia repositoryCompetencia) => _repositoryCompetencia = repositoryCompetencia;
        private Competencia _competencia;

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Incluir", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("CompetenciaIncluirRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (CompetenciaIncluirRequest)request;
            _competencia = new Competencia();
            _competencia.Incluir(requestClasse.Descricao);
            AddNotifications(_competencia);
            if (IsInvalid()) return null;
            _competencia = _repositoryCompetencia.Adicionar(_competencia);

            return (ResponseBase)_competencia.Id;
        }

        public IResponse Alterar(IRequest request)
        {
            if (request is null) AddNotification("Alterar", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("CompetenciaAlterarRequest"));
            if (IsInvalid()) return null;
           
            var requestClasse = (CompetenciaAlterarRequest)request;
            _competencia = _repositoryCompetencia.ObterPorId(requestClasse.Id);
            if (_competencia == null)
            {
                AddNotification("Competência", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _competencia.Alterar(requestClasse.Id, requestClasse.Descricao);
            _competencia = _repositoryCompetencia.Editar(_competencia);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IResponse Excluir(Guid id)
        {
            _competencia = _repositoryCompetencia.ObterPorId(id);
            if (_competencia == null)
            {
                AddNotification("Competência", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryCompetencia.Remover(_competencia);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }


        public IEnumerable<IResponse> Listar()
        {
            return _repositoryCompetencia.ListarOrdenadosPor(item => item.Descricao).ToList().Select(competencia => (CompetenciaResponse)competencia);

        }

        public IEnumerable<CompetenciaResponse> ListarFiltrado(string descricao)
        {
            return _repositoryCompetencia.ListarPor(item => item.Descricao.Contains(descricao)).ToList().Select(competencia => (CompetenciaResponse)competencia);
        }
    }
}
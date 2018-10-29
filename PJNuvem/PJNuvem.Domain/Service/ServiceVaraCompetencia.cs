using PJNuvem.Domain.Arguments.Base;
using PJNuvem.Domain.Arguments.VarasCompetencias;
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
    public class ServiceVaraCompetencia : Notifiable, IServiceVaraCompetencia
    {
        private readonly IRepositoryVaraCompetencia _repositoryVaraCompetencia;
        public ServiceVaraCompetencia() { }
        public ServiceVaraCompetencia(IRepositoryVaraCompetencia repositoryVaraCompetencia) => _repositoryVaraCompetencia = repositoryVaraCompetencia;
        private VaraCompetencia _VaraCompetencia;

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Incluir", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("VaraCompetenciaIncluirRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (VaraCompetenciaIncluirRequest)request;
            _VaraCompetencia = new VaraCompetencia();
            _VaraCompetencia.Incluir(requestClasse.VaraId, requestClasse.CompetenciaId);
            AddNotifications(_VaraCompetencia);
            if (IsInvalid()) return null;
            _VaraCompetencia = _repositoryVaraCompetencia.Adicionar(_VaraCompetencia);

            return (ResponseBase)_VaraCompetencia.Id;
        }

        public IResponse Alterar(IRequest request)
        {
            if (request is null) AddNotification("Alterar", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("VaraCompetenciaAlterarRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (VaraCompetenciaAlterarRequest)request;
            _VaraCompetencia = _repositoryVaraCompetencia.ObterPorId(requestClasse.Id);
            if (_VaraCompetencia == null)
            {
                AddNotification("Competências da vara", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _VaraCompetencia.Alterar(requestClasse.Id, requestClasse.VaraId, requestClasse.CompetenciaId);
            _VaraCompetencia = _repositoryVaraCompetencia.EditarRemovendoProperties(_VaraCompetencia, remove => remove.QuantidadeProcessos);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IResponse Excluir(Guid id)
        {
            _VaraCompetencia = _repositoryVaraCompetencia.ObterPorId(id);
            if (_VaraCompetencia == null)
            {
                AddNotification("Competências da vara", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryVaraCompetencia.Remover(_VaraCompetencia);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }


        public IEnumerable<IResponse> Listar()
        {
            return _repositoryVaraCompetencia.ListarOrdenadosPor(item => item.Vara.Descricao, true, include => include.Vara, include => include.Competencia).ToList().Select(VaraCompetencia => (VaraCompetenciaResponse)VaraCompetencia);
        }

        public IEnumerable<VaraCompetenciaResponse> ListarFiltrado(string filtro)
        {
            return _repositoryVaraCompetencia.ListarPor(item => item.Vara.Descricao.Contains(filtro) || item.Competencia.Descricao.Contains(filtro), include => include.Vara, include => include.Competencia).ToList().Select(VaraCompetencia => (VaraCompetenciaResponse)VaraCompetencia);
        }

        public void AtualizaQuantidadeDeProcessos(Guid id)
        {
            var varaCompetencia = _repositoryVaraCompetencia.ListarPor(item => item.VaraId == id).OrderBy(item => item.QuantidadeProcessos).FirstOrDefault();
            if (varaCompetencia == null)
            {
                AddNotification("Competência da vara", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return;
            }

            varaCompetencia.PreencheNovaQuantidadeDeProcessos(varaCompetencia.QuantidadeProcessos + 1);
            _repositoryVaraCompetencia.Editar(varaCompetencia);
        }
    }
}
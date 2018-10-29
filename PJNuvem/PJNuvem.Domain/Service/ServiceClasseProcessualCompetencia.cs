using PJNuvem.Domain.Arguments.Base;
using PJNuvem.Domain.Arguments.ClassesProcessuaisCompetencias;
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
    public class ServiceClasseProcessualCompetencia : Notifiable, IServiceClasseProcessualCompetencia
    {
        private readonly IRepositoryClasseProcessualCompetencia _repositoryClasseProcessualCompetencia;
        public ServiceClasseProcessualCompetencia() { }
        public ServiceClasseProcessualCompetencia(IRepositoryClasseProcessualCompetencia repositoryClasseProcessualCompetencia) => _repositoryClasseProcessualCompetencia = repositoryClasseProcessualCompetencia;
        private ClasseProcessualCompetencia _ClasseProcessualCompetencia;

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Incluir", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("ClasseProcessualCompetenciaIncluirRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (ClasseProcessualCompetenciaIncluirRequest)request;
            _ClasseProcessualCompetencia = new ClasseProcessualCompetencia();
            _ClasseProcessualCompetencia.Incluir(requestClasse.ClasseProcessualId, requestClasse.CompetenciaId);
            AddNotifications(_ClasseProcessualCompetencia);
            if (IsInvalid()) return null;
            _ClasseProcessualCompetencia = _repositoryClasseProcessualCompetencia.Adicionar(_ClasseProcessualCompetencia);

            return (ResponseBase)_ClasseProcessualCompetencia.Id;
        }

        public IResponse Alterar(IRequest request)
        {
            if (request is null) AddNotification("Alterar", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("ClasseProcessualCompetenciaAlterarRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (ClasseProcessualCompetenciaAlterarRequest)request;
            _ClasseProcessualCompetencia = _repositoryClasseProcessualCompetencia.ObterPorId(requestClasse.Id);
            if (_ClasseProcessualCompetencia == null)
            {
                AddNotification("Competências da ClasseProcessual", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _ClasseProcessualCompetencia.Alterar(requestClasse.Id, requestClasse.ClasseProcessualId, requestClasse.CompetenciaId);
            _ClasseProcessualCompetencia = _repositoryClasseProcessualCompetencia.Editar(_ClasseProcessualCompetencia);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IResponse Excluir(Guid id)
        {
            _ClasseProcessualCompetencia = _repositoryClasseProcessualCompetencia.ObterPorId(id);
            if (_ClasseProcessualCompetencia == null)
            {
                AddNotification("ClasseProcessualCompetencia", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryClasseProcessualCompetencia.Remover(_ClasseProcessualCompetencia);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }


        public IEnumerable<IResponse> Listar()
        {
            return _repositoryClasseProcessualCompetencia.ListarOrdenadosPor(item => item.ClasseProcessual.Descricao, true, include => include.ClasseProcessual, include => include.Competencia).ToList().Select(ClasseProcessualCompetencia => (ClasseProcessualCompetenciaResponse)ClasseProcessualCompetencia);

        }

        public IEnumerable<ClasseProcessualCompetenciaResponse> ListarFiltrado(string filtro)
        {
            return _repositoryClasseProcessualCompetencia.ListarPor(item => item.ClasseProcessual.Descricao.Contains(filtro) || item.Competencia.Descricao.Contains(filtro), include => include.ClasseProcessual, include => include.Competencia).ToList().Select(ClasseProcessualCompetencia => (ClasseProcessualCompetenciaResponse)ClasseProcessualCompetencia);
        }

        public IEnumerable<Guid> RetornaCompetenciasDaClasseProcessual(Guid classeProcessual)
        {
            return _repositoryClasseProcessualCompetencia.ListarPor(item => item.ClasseProcessualId == classeProcessual).Select(item => item.CompetenciaId).ToList();
        }
    }
}
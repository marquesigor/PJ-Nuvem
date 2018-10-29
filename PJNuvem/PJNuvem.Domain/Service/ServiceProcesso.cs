using PJNuvem.Domain.Arguments.Base;
using PJNuvem.Domain.Arguments.Processos;
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
    public class ServiceProcesso : Notifiable, IServiceProcesso
    {
        private readonly IRepositoryProcesso _repositoryProcesso;
        public ServiceProcesso() { }
        public ServiceProcesso(IRepositoryProcesso repositoryProcesso) => _repositoryProcesso = repositoryProcesso;
        private Processo _Processo;
        private Guid _varaId;

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Incluir", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("ProcessoIncluirRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (ProcessoIncluirRequest)request;
            _Processo = new Processo();
            _Processo.Incluir(requestClasse.UsuarioId, requestClasse.ComarcaId, requestClasse.ClasseProcessualId, _varaId);
            AddNotifications(_Processo);
            if (IsInvalid()) return null;
            _Processo = _repositoryProcesso.Adicionar(_Processo);

            return (ResponseBase)_Processo.Id;
        }

        private IEnumerable<Guid> RetornaCompetenciasDaClasseProcessual()
        {
            return new ServiceClasseProcessualCompetencia().RetornaCompetenciasDaClasseProcessual(_Processo.ClasseProcessualId);
        }

        public IResponse Alterar(IRequest request)
        {
            return new ResponseBase() { Mensagem = Messages_PT_BR.METODO_INDISPONIVEL_PARA_ESSA_ENTIDADE};
        }

        public IResponse Excluir(Guid id)
        {
            return new ResponseBase() { Mensagem = Messages_PT_BR.METODO_INDISPONIVEL_PARA_ESSA_ENTIDADE};
        }


        public IEnumerable<IResponse> Listar()
        {
            return _repositoryProcesso.ListarOrdenadosPor(item => item.Vara.Descricao, true,
                include => include.Usuario, include => include.ClasseProcessual, include => include.Comarca, include => include.Vara).ToList().Select(Processo => (ProcessoResponse)Processo);
        }

        public IEnumerable<ProcessoResponse> ListarFiltrado(string filtro)
        {
            return _repositoryProcesso.ListarPor(item => item.Vara.Descricao.Contains(filtro) || item.Comarca.Descricao.Contains(filtro),
                include => include.Usuario, include => include.ClasseProcessual, include => include.Comarca, include => include.Vara).ToList().Select(Processo => (ProcessoResponse)Processo);
        }

        public void PreencheVaraId(Guid id)
        {
            _varaId = id;
        }
    }
}
using PJNuvem.Domain.Arguments.Base;
using PJNuvem.Domain.Arguments.ClassesProcessuais;
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
    public class ServiceClasseProcessual : Notifiable, IServiceClasseProcessual
    {
        private readonly IRepositoryClasseProcessual _repositoryClasseProcessual;
        public ServiceClasseProcessual() { }
        public ServiceClasseProcessual(IRepositoryClasseProcessual repositoryClasseProcessual) => _repositoryClasseProcessual = repositoryClasseProcessual;
        private ClasseProcessual _ClasseProcessual;

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Incluir", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("ClasseProcessualIncluirRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (ClasseProcessualIncluirRequest)request;
            _ClasseProcessual = new ClasseProcessual();
            _ClasseProcessual.Incluir(requestClasse.Descricao);
            AddNotifications(_ClasseProcessual);
            if (IsInvalid()) return null;
            _ClasseProcessual = _repositoryClasseProcessual.Adicionar(_ClasseProcessual);

            return (ResponseBase)_ClasseProcessual.Id;
        }

        public IResponse Alterar(IRequest request)
        {
            if (request is null) AddNotification("Alterar", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("ClasseProcessualAlterarRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (ClasseProcessualAlterarRequest)request;
            _ClasseProcessual = _repositoryClasseProcessual.ObterPorId(requestClasse.Id);
            if (_ClasseProcessual == null)
            {
                AddNotification("Classes processuais", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _ClasseProcessual.Alterar(requestClasse.Id, requestClasse.Descricao);
            _ClasseProcessual = _repositoryClasseProcessual.Editar(_ClasseProcessual);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IResponse Excluir(Guid id)
        {
            _ClasseProcessual = _repositoryClasseProcessual.ObterPorId(id);
            if (_ClasseProcessual == null)
            {
                AddNotification("Classes processuais", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryClasseProcessual.Remover(_ClasseProcessual);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }


        public IEnumerable<IResponse> Listar()
        {
            return _repositoryClasseProcessual.ListarOrdenadosPor(item => item.Descricao).ToList().Select(ClasseProcessual => (ClasseProcessualResponse)ClasseProcessual);

        }

        public IEnumerable<ClasseProcessualResponse> ListarFiltrado(string descricao)
        {
            return _repositoryClasseProcessual.ListarPor(item => item.Descricao.Contains(descricao)).ToList().Select(ClasseProcessual => (ClasseProcessualResponse)ClasseProcessual);
        }
    }
}
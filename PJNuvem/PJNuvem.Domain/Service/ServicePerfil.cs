using PJNuvem.Domain.Arguments.Base;
using PJNuvem.Domain.Arguments.Perfis;
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
    public class ServicePerfil : Notifiable, IServicePerfil
    {
        private readonly IRepositoryPerfil _repositoryPerfil;
        public ServicePerfil() { }
        public ServicePerfil(IRepositoryPerfil repositoryPerfil) => _repositoryPerfil = repositoryPerfil;

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Incluir", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("PerfilIncluirRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (PerfilIncluirRequest)request;
            var perfil = new Perfil();
            perfil.Incluir(requestClasse.Descricao);
            perfil = _repositoryPerfil.Adicionar(perfil);

            return (ResponseBase)perfil.Id;
        }

        public IResponse Alterar(IRequest request)
        {
            if (request is null) AddNotification("Alterar", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("PerfilAlterarRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (PerfilAlterarRequest)request;
            var perfil = _repositoryPerfil.ObterPorId(requestClasse.Id);
            if (perfil == null)
            {
                AddNotification("Perfil", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            perfil.Alterar(requestClasse.Id, requestClasse.Descricao);
            perfil = _repositoryPerfil.Editar(perfil);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IResponse Excluir(Guid id)
        {
            var perfil = _repositoryPerfil.ObterPorId(id);
            if (perfil == null)
            {
                AddNotification("Perfil", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryPerfil.Remover(perfil);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }


        public IEnumerable<IResponse> Listar()
        {
            return _repositoryPerfil.ListarOrdenadosPor(item => item.Descricao).ToList().Select(perfil => (PerfilResponse)perfil).ToList();

        }

        public IEnumerable<PerfilResponse> ListarFiltrado(string descricao)
        {
            return _repositoryPerfil.ListarPor(item => item.Descricao.Contains(descricao)).ToList().Select(perfil => (PerfilResponse)perfil).ToList();
        }
    }
}

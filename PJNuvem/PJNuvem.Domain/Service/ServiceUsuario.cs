using PJNuvem.Domain.Arguments.Base;
using PJNuvem.Domain.Arguments.Login;
using PJNuvem.Domain.Arguments.Usuarios;
using PJNuvem.Domain.Interfaces.Arguments;
using PJNuvem.Domain.Interfaces.Repositories;
using PJNuvem.Domain.Interfaces.Services;
using PJNuvem.Domain.Model;
using PJNuvem.Domain.Resources;
using PJNuvem.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PJNuvem.Domain.Service
{
    public class ServiceUsuario : Notifiable, IServiceUsuario
    {
        private Usuario _usuario;
        private readonly IRepositoryUsuario _repositoryUsuario;
        public ServiceUsuario()
        {

        }
        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Incluir", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("UsuarioIncluirRequest"));
            if (IsInvalid()) return null;
            PreparaClasseUsuario(request);
            if (IsInvalid()) return null;
            _usuario = _repositoryUsuario.Adicionar(_usuario);

            return (UsuarioIncluirResponse)_usuario.Id;
        }

        public IResponse Alterar(IRequest request)
        {
            if (request is null) AddNotification("Alterar", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("UsuarioAlterarRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (UsuarioAlterarRequest)request;
            _usuario = _repositoryUsuario.ObterPorId(requestClasse.Id);
            if (_usuario == null)
            {
                AddNotification("Usuário", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            var email = new Email(requestClasse.Email);
            var nome = new Nome(requestClasse.PrimeiroNome, requestClasse.UltimoNome);
            _usuario.Alterar(requestClasse.Id, email, nome, requestClasse.Perfil);
            AddNotifications(_usuario, email, nome);
            ValidaSeUsuarioExiste(email.Endereco, _usuario.Id);
            if (IsInvalid()) return null;

            _usuario = _repositoryUsuario.EditarRemovendoProperties(_usuario, item => item.Senha);
            return (ResponseBase)_usuario.Id;
        }

        public IResponse Excluir(Guid id)
        {
            _usuario = _repositoryUsuario.ObterPorId(id);
            if (_usuario == null)
            {
                AddNotification("Usuário", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryUsuario.Remover(_usuario);

            return new ResponseBase() { Mensagem = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public UsuarioLoginResponse Autenticar(UsuarioLoginRequest request)
        {
            if (request is null) AddNotification("Autenticar", Messages_PT_BR.OBJETO_X0_E_OBRIGATORIO.ToFormat("LoginRequest"));
            if (IsInvalid()) return null;

            var email = new Email(request.Email);
            _usuario =  new Usuario();
            _usuario.Autenticar(email, request.Senha);
            AddNotifications(_usuario, email);
            if (IsInvalid()) return null;

            _usuario = _repositoryUsuario.ObterPor(item => item.Email.Endereco == _usuario.Email.Endereco && item.Senha == _usuario.Senha, include => include.Perfil);
            if (_usuario is null)
            {
                AddNotification("Autenticar", Messages_PT_BR.DADOS_NAO_ENCONTRADOS);
                return null;
            }
            return (UsuarioLoginResponse)_usuario;
        }

        public IEnumerable<IResponse> Listar()
        {
            return _repositoryUsuario.Listar(include => include.Perfil).ToList().Select(usuario => (UsuarioResponse)usuario);
        }

        private void ValidaSeUsuarioExiste(string email, Guid id)
        {
            if (_repositoryUsuario.Existe(item => (item.Email.Endereco == email) && (item.Id != id))) AddNotification("E-mail", Messages_PT_BR.JA_EXISTE_UM_X0_CHAMADO_X1.ToFormat("e-mail", email));
        }

        private void PreparaClasseUsuario(IRequest request)
        {
            UsuarioIncluirRequest requestClasse = (UsuarioIncluirRequest)request;
            var email = new Email(requestClasse.Email);
            var nome = new Nome(requestClasse.PrimeiroNome, requestClasse.UltimoNome);
            _usuario = new Usuario();
            _usuario.Incluir(email, nome, requestClasse.Senha, requestClasse.Perfil);
            ValidaSeUsuarioExiste(email.Endereco, _usuario.Id);
            AddNotifications(_usuario, email, nome);
        }

        public IEnumerable<UsuarioResponse> ListarFiltrado(UsuarioFiltroRequest request)
        {
            return _repositoryUsuario.ListarPor(item => item.Nome.PrimeiroNome.Contains(request.Nome) || item.Nome.UltimoNome.Contains(request.Nome) || item.Email.Endereco.Contains(request.Email), include => include.Perfil)
                .ToList().Select(usuario => (UsuarioResponse)usuario);
        }
    }
}


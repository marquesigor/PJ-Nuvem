using PJNuvem.Domain.Arguments.Login;
using PJNuvem.Domain.Interfaces.Services;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace PJNuvem.Api.Security
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private readonly UnityContainer _container;

        public AuthorizationProvider(UnityContainer container)
        {
            _container = container;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                IServiceUsuario serviceUsuario = _container.Resolve<IServiceUsuario>();
                var request = new UsuarioLoginRequest();
                request.Email = context.UserName;
                request.Senha = context.Password;
                UsuarioLoginResponse response = serviceUsuario.Autenticar(request);

                if ((serviceUsuario.IsInvalid()) || (response == null))
                {
                    context.SetError("invalid_grant", "Usuário não encontrado.");
                    serviceUsuario.ClearNotifications();
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, response.Nome));
                identity.AddClaim(new Claim(ClaimTypes.Role, response.Perfil));

                var roles = new List<string>();
                roles.Add(response.Perfil);

                var principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;
                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return;
            }
        }
    }
}

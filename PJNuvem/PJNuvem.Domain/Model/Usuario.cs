using PJNuvem.Domain.Extensions;
using PJNuvem.Domain.Model.Base;
using PJNuvem.Domain.Resources;
using PJNuvem.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace PJNuvem.Domain.Model
{
    public class Usuario : ModelBase
    {
        public Email Email { get; private set; }
        public Nome Nome { get; private set; }
        public string Senha { get; private set; }
        public Guid PerfilId { get; private set; }
        public virtual Perfil Perfil { get; private set; }

        public Usuario() { }

        public void Autenticar(Email email, string senha)
        {
            Email = email;
            Senha = senha;
            new AddNotifications<Usuario>(this).IfNullOrInvalidLength(item => item.Senha, 6, 32, Messages_PT_BR.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "6", "32"));

            if (IsValid()) Senha = Senha.Criptografa();
        }

        public void Incluir(Email email, Nome nome, string senha, Guid perfilId)
        {
            Email = email;
            Nome = nome;
            Senha = senha;
            PerfilId = perfilId;

            ValidaModelUsuario();
            if (IsValid()) Senha = Senha.Criptografa();
        }

        public void Alterar(Guid id, Email email, Nome nome, Guid perfilId)
        {
            Id = id;
            Email = email;
            Nome = nome;
            PerfilId = perfilId;
        }

        private void ValidaModelUsuario()
        {
            new AddNotifications<Usuario>(this).IfNullOrInvalidLength(item => item.Senha, 6, 32, Messages_PT_BR.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "6", "32"));
        }
    }
}

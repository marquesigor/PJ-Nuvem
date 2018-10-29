using PJNuvem.Domain.Interfaces.Arguments;
using PJNuvem.Domain.Model;
using System;

namespace PJNuvem.Domain.Arguments.Usuarios
{
    public class UsuarioResponse : IResponse
    {
        public string Email { get; private set; }
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public Guid PerfilId { get; private set; }
        public virtual Perfil Perfil { get; private set; }

        public static explicit operator UsuarioResponse(Model.Usuario model)
        {
            return new UsuarioResponse()
            {
                Email = model.Email.Endereco,
                PrimeiroNome = model.Nome.PrimeiroNome,
                UltimoNome = model.Nome.UltimoNome,
                PerfilId = model.PerfilId,
                Perfil = model.Perfil
            };
        }
    }
}

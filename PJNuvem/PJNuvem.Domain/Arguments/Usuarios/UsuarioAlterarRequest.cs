using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.Usuarios
{
    public class UsuarioAlterarRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public Guid Perfil { get; set; }
    }
}

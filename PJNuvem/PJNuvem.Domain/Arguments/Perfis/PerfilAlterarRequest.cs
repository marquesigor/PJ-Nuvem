using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.Perfis
{
    public class PerfilAlterarRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}

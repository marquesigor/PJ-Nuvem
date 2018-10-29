using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.Comarcas
{
    public class ComarcaAlterarRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}

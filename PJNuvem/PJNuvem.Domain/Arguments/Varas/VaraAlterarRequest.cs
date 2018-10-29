using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.Varas
{
    public class VaraAlterarRequest : IRequest
    {
        public Guid Id { get; set; }
        public Guid ComarcaId { get; set; }
        public string Descricao { get; set; }
    }
}

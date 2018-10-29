using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.Varas
{
    public class VaraIncluirRequest : IRequest
    {
        public Guid ComarcaId { get; set; }
        public string Descricao { get; set; }
    }
}

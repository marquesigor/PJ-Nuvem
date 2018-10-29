using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.Processos
{
    public class ProcessoIncluirRequest : IRequest
    {
        public Guid UsuarioId { get; set; }
        public Guid ClasseProcessualId { get; set; }
        public Guid ComarcaId { get; set; }
    }
}

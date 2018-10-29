using PJNuvem.Domain.Interfaces.Arguments;
using PJNuvem.Domain.Model;
using System;

namespace PJNuvem.Domain.Arguments.Processos
{
    public class ProcessoResponse : IResponse
    {
        public Guid Id { get; set; }
        public Guid NumeroUnico { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public Guid ClasseProcessualId { get; private set; }
        public virtual ClasseProcessual ClasseProcessual { get; set; }
        public Guid ComarcaId { get; set; }
        public virtual Comarca Comarca { get; set; }
        public Guid VaraId { get; set; }
        public virtual Vara Vara { get; set; }

        public static explicit operator ProcessoResponse(Model.Processo model)
        {
            return new ProcessoResponse()
            {
                Id = model.Id,
                NumeroUnico = model.NumeroUnico,
                UsuarioId = model.UsuarioId,
                Usuario = model.Usuario,
                ComarcaId = model.ComarcaId,
                Comarca = model.Comarca,
                VaraId = model.VaraId,
                Vara = model.Vara,
                ClasseProcessualId = model.ClasseProcessualId,
                ClasseProcessual = model.ClasseProcessual
            };
        }
    }
}

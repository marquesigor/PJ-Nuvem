using PJNuvem.Domain.Model.Base;
using System;
using System.Collections.Generic;

namespace PJNuvem.Domain.Model
{
    public class Processo : ModelBase
    {
        public Processo()
        {
            NumeroUnico = Guid.NewGuid();
        }

        public Guid NumeroUnico { get; private set; }
        public Guid UsuarioId { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public Guid ClasseProcessualId { get; private set; }
        public virtual ClasseProcessual ClasseProcessual { get; private set; }
        public Guid ComarcaId { get; private set; }
        public virtual Comarca Comarca { get; private set; }
        public Guid VaraId { get; private set; }
        public virtual Vara Vara { get; private set; }

        public void Incluir(Guid usuarioId, Guid comarcaId, Guid classeProcessualId, Guid varaId)
        {
            VaraId = varaId;
            ClasseProcessualId = classeProcessualId;
            ComarcaId = comarcaId;
            UsuarioId = usuarioId;
        }

        public void Alterar(Guid id, Guid usuarioId, Guid varaId, Guid comarcaId, Guid classeProcessualId)
        {
            Id = id;
            VaraId = varaId;
            ClasseProcessualId = classeProcessualId;
            ComarcaId = comarcaId;
            UsuarioId = usuarioId;
        }
    }
}

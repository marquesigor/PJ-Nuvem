using PJNuvem.Domain.Model.Base;
using System;

namespace PJNuvem.Domain.Model
{
    public class ClasseProcessualCompetencia : ModelBase
    {
        public Guid ClasseProcessualId { get; private set; }
        public virtual ClasseProcessual ClasseProcessual { get; private set; }
        public Guid CompetenciaId { get; private set; }
        public virtual Competencia Competencia { get; private set; }

        public void Incluir(Guid classeProcessualId, Guid competenciaId)
        {
            ClasseProcessualId = classeProcessualId;
            CompetenciaId = competenciaId;
        }

        public void Alterar(Guid id, Guid classeProcessualId, Guid competenciaId)
        {
            Id = id;
            ClasseProcessualId = classeProcessualId;
            CompetenciaId = competenciaId;
        }
    }
}

using PJNuvem.Domain.Model.Base;
using System;

namespace PJNuvem.Domain.Model
{
    public class VaraCompetencia : ModelBase
    {
        public Guid VaraId { get; private set; }
        public virtual Vara Vara { get; private set; }
        public Guid CompetenciaId { get; private set; }
        public virtual Competencia Competencia { get; private set; }
        public int QuantidadeProcessos { get; private set; }

        public void Incluir(Guid varaId, Guid competenciaId)
        {
            VaraId = varaId;
            CompetenciaId = competenciaId;
            QuantidadeProcessos = 0;
        }

        public void Alterar(Guid id, Guid varaId, Guid competenciaId)
        {
            Id = id;
            VaraId = varaId;
            CompetenciaId = competenciaId;
        }

        public void PreencheNovaQuantidadeDeProcessos(int quantidade)
        {
            QuantidadeProcessos = quantidade;
        }
    }
}

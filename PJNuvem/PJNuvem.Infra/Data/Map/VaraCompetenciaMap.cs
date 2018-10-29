using PJNuvem.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace PJNuvem.Infra.Data.Map
{
    public class VaraCompetenciaMap : EntityTypeConfiguration<VaraCompetencia>
    {
        public VaraCompetenciaMap()
        {
            ToTable("VaraCompetencia");
            HasRequired(item => item.Vara).WithMany().HasForeignKey(fk => fk.VaraId).WillCascadeOnDelete(false);
            Property(item => item.QuantidadeProcessos).IsRequired();
            HasRequired(item => item.Competencia).WithMany().HasForeignKey(fk => fk.CompetenciaId).WillCascadeOnDelete(false);
        }
    }
}

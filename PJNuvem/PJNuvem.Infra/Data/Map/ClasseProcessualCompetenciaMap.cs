using PJNuvem.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace PJNuvem.Infra.Data.Map
{
    public class ClasseProcessualCompetenciaMap : EntityTypeConfiguration<ClasseProcessualCompetencia>
    {
        public ClasseProcessualCompetenciaMap()
        {
            ToTable("ClasseProcessualCompetencia");
            HasRequired(item => item.ClasseProcessual).WithMany().HasForeignKey(fk => fk.ClasseProcessualId).WillCascadeOnDelete(false);
            HasRequired(item => item.Competencia).WithMany().HasForeignKey(fk => fk.CompetenciaId).WillCascadeOnDelete(false);
        }
    }
}

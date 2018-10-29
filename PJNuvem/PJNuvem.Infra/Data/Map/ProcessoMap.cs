using PJNuvem.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace PJNuvem.Infra.Data.Map
{
    public class ProcessoMap : EntityTypeConfiguration<Processo>
    {
        public ProcessoMap()
        {
            ToTable("Processo");
            HasRequired(item => item.Usuario).WithMany().HasForeignKey(fk => fk.UsuarioId).WillCascadeOnDelete(false);
            HasRequired(item => item.Comarca).WithMany().HasForeignKey(fk => fk.ComarcaId).WillCascadeOnDelete(false);
            HasRequired(item => item.ClasseProcessual).WithMany().HasForeignKey(fk => fk.ClasseProcessualId).WillCascadeOnDelete(false);
            HasRequired(item => item.Vara).WithMany().HasForeignKey(fk => fk.VaraId).WillCascadeOnDelete(false);
        }
    }
}

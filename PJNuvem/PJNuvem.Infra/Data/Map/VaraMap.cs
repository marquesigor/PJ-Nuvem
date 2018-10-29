using PJNuvem.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace PJNuvem.Infra.Data.Map
{
    public class VaraMap : EntityTypeConfiguration<Vara>
    {
        public VaraMap()
        {
            ToTable("Vara");
            Property(item => item.Descricao).IsRequired().HasMaxLength(200);
            HasRequired(item => item.Comarca).WithMany().HasForeignKey(fk => fk.ComarcaId).WillCascadeOnDelete(false);
        }
    }
}

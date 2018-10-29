using PJNuvem.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace PJNuvem.Infra.Data.Map
{
    public class ComarcaMap : EntityTypeConfiguration<Comarca>
    {
        public ComarcaMap()
        {
            ToTable("Comarca");
            Property(item => item.Descricao).IsRequired().HasMaxLength(200);
        }
    }
}

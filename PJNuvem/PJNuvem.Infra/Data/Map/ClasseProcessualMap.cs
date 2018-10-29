using PJNuvem.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace PJNuvem.Infra.Data.Map
{
    public class ClasseProcessualMap : EntityTypeConfiguration<ClasseProcessual>
    {
        public ClasseProcessualMap()
        {
            ToTable("ClasseProcessual");
            Property(item => item.Descricao).IsRequired().HasMaxLength(200);
        }
    }
}

using PJNuvem.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace PJNuvem.Infra.Data.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            Property(item => item.Email.Endereco).HasMaxLength(200).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_Usuario_EMAIL") { IsUnique = true })).HasColumnName("Email");
            Property(item => item.Senha).IsRequired().HasMaxLength(32);
            Property(item => item.Nome.PrimeiroNome).IsRequired().HasMaxLength(50).HasColumnName("PrimeiroNome");
            Property(item => item.Nome.UltimoNome).IsRequired().HasMaxLength(100).HasColumnName("UltimoNome");
            HasRequired(item => item.Perfil).WithMany().HasForeignKey(item => item.PerfilId).WillCascadeOnDelete(false);
        }
    }
}

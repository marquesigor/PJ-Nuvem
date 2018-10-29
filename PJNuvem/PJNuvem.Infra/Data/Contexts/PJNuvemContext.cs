using PJNuvem.Domain.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PJNuvem.Infra.Data.Contexts
{
    public class PJNuvemContext : DbContext
    {
        public PJNuvemContext() : base("AppConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Processo> Processos { get; set; }
        public DbSet<Vara> Varas { get; set; }
        public DbSet<VaraCompetencia> VaraCompetencia { get; set; }
        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<Comarca> Comarcas { get; set; }
        public DbSet<ClasseProcessual> ClassesProcessuais { get; set; }
        public DbSet<ClasseProcessualCompetencia> ClasseProcessualCompetencia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));
            modelBuilder.Configurations.AddFromAssembly(typeof(PJNuvemContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

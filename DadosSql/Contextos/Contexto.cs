using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using DadosSql.Entities;
using DadosSql.EntityMap;

namespace DadosSql.Contextos
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base(ConfigurationManager.ConnectionStrings["ConnectionSQL"].ConnectionString)
        {
            
        }

        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Cooperativa> Cooperativa { get; set; }
        public DbSet<Operadora> Operadora { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Plano> Plano { get; set; }
        public DbSet<Telefone> Telefone { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(200));

            modelBuilder.Configurations.Add(new AdministradorMap());
            modelBuilder.Configurations.Add(new CooperativaMap());
            modelBuilder.Configurations.Add(new OperadoraMap());
            modelBuilder.Configurations.Add(new PagamentoMap());
            modelBuilder.Configurations.Add(new PlanoMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
        }
    }
}

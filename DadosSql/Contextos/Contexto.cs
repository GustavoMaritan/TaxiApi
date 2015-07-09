using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DadosSql.Entidades;
using DadosSql.Mapeamento;

namespace DadosSql.Contextos
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base(@"Data Source=(LocalDb)\v11.0;Initial Catalog = Coperativas;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
        }

        public DbSet<Coperativa> DbCoperativa { get; set; }
        public DbSet<Telefone> DbTelefone { get; set; }
        public DbSet<ControleMensal> DbControleMensal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(200));

            modelBuilder.Configurations.Add(new CoperativaMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
            modelBuilder.Configurations.Add(new ControleMensalMap());
        }
    }
}

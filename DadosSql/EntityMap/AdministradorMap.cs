using System.Data.Entity.ModelConfiguration;
using DadosSql.Entities;

namespace DadosSql.EntityMap
{
    public class AdministradorMap : EntityTypeConfiguration<Administrador>
    {
        public AdministradorMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Email).IsRequired().HasMaxLength(100);
            Property(x => x.Senha).IsRequired().HasMaxLength(30);
            Property(x => x.Nome).IsRequired().HasMaxLength(50);
            Property(x => x.Login).IsRequired().HasMaxLength(30);
            Property(x => x.Image).IsOptional();
        }
    }
}

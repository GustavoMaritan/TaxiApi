using System.Data.Entity.ModelConfiguration;
using DadosSql.Entidades;

namespace DadosSql.Mapeamento
{
    public class AdministradorMap : EntityTypeConfiguration<Administrador>
    {
        public AdministradorMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Email).IsRequired();
            Property(x => x.Senha).IsRequired();
            Property(x => x.Nome).IsRequired();
            Property(x => x.Login).IsRequired();
        }
    }
}
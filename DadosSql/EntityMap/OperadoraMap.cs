using System.Data.Entity.ModelConfiguration;
using DadosSql.Entities;

namespace DadosSql.EntityMap
{
    public class OperadoraMap : EntityTypeConfiguration<Operadora>
    {
        public OperadoraMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired().HasMaxLength(30);
        }
    }
}

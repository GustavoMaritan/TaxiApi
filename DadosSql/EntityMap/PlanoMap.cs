using System.Data.Entity.ModelConfiguration;
using DadosSql.Entities;

namespace DadosSql.EntityMap
{
    public class PlanoMap : EntityTypeConfiguration<Plano>
    {
        public PlanoMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Descricao).IsRequired().HasMaxLength(50);
            Property(x => x.QuantidadeMaximaTelefones).IsRequired();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadosSql.Entidades;

namespace DadosSql.Mapeamento
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            HasKey(x => x.Id);

            HasRequired(c => c.Coperativa)
              .WithMany()
              .HasForeignKey(x => x.CoperativaId);

            Property(x => x.Ddd).IsRequired();
            Property(x => x.Numero).IsRequired();
            Property(x => x.Ramal).IsOptional();
        }
    }
}

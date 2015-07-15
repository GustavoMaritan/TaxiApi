using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadosSql.Entities;

namespace DadosSql.EntityMap
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            HasKey(x => x.Id);

            HasRequired(c => c.Cooperativa)
              .WithMany(c => c.Telefones)
              .HasForeignKey(x => x.CooperativaId);

            HasRequired(c => c.Operadora)
             .WithMany(c => c.Telefones)
             .HasForeignKey(x => x.OperadoraId);

            Property(x => x.Ddd).IsRequired();
            Property(x => x.Numero).IsRequired();
            Property(x => x.Ramal).IsOptional();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadosSql.Entidades;

namespace DadosSql.Mapeamento
{
    public class ControleMensalMap : EntityTypeConfiguration<ControleMensal>
    {
        public ControleMensalMap()
        {
            HasKey(x => x.Id);

            HasRequired(c => c.Coperativa)
              .WithMany()
              .HasForeignKey(x => x.CoperativaId);

            Property(x => x.DataContrato).IsRequired(); 
            Property(x => x.DataVencimento).IsRequired(); 
            Property(x => x.Recebido).IsRequired();
            Property(x => x.Valor).IsRequired();
        }
    }
}

using System.Data.Entity.ModelConfiguration;
using DadosSql.Entities;

namespace DadosSql.EntityMap
{
    public class PagamentoMap : EntityTypeConfiguration<Pagamento>
    {
        public PagamentoMap()
        {
            HasKey(x => x.Id);

            HasRequired(c => c.Cooperativa)
                .WithMany(c => c.Pagamentos)
                .HasForeignKey(c => c.CooperativaId);

            Property(x => x.DataVencimento).IsRequired();
            Property(x => x.Recebido).IsRequired();
            Property(x => x.Valor).IsRequired();
        }
    }
}

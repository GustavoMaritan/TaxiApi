using System.Data.Entity.ModelConfiguration;
using DadosSql.Entities;

namespace DadosSql.EntityMap
{
    public class CooperativaMap : EntityTypeConfiguration<Cooperativa>
    {
        public CooperativaMap()
        {
            HasKey(x => x.Id);

            HasMany(x => x.Pagamentos);
            HasMany(x => x.Telefones);
            //HasRequired(x => x.Plano).WithMany(x => x.Cooperativas);

            Property(x => x.Ativo).IsRequired();
            Property(x => x.Excluido).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.Descricao).IsRequired().HasMaxLength(50);
            Property(x => x.Senha).IsRequired().HasMaxLength(30);
            Property(x => x.Login).IsRequired().HasMaxLength(30);
            Property(x => x.Cnpj).IsRequired();
            Property(x => x.RazaoSocial).IsRequired().HasMaxLength(100);
            Property(x => x.Endereco).IsRequired().HasMaxLength(100);
            Property(x => x.Bairro).IsRequired().HasMaxLength(50);
            Property(x => x.Cep).IsRequired();
            Property(x => x.Numero).IsRequired();
            Property(x => x.DiaPagamento).IsRequired();
        }
    }
}

using System.Data.Entity.ModelConfiguration;
using DadosSql.Entidades;

namespace DadosSql.Mapeamento
{
    public class CoperativaMap : EntityTypeConfiguration<Coperativa>
    {
        public CoperativaMap()
        {
            HasKey(x => x.Id);

            HasMany(x => x.Controles);
            HasMany(x => x.Telefones);

            Property(x => x.Ativo).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Senha).IsRequired();
            Property(x => x.Login).IsRequired();
            Property(x => x.Cnpj).IsRequired();
            Property(x => x.RazaoSocial).IsRequired();
            Property(x => x.QtdeTelefones).IsRequired();
            Property(x => x.Endereco).IsRequired();
            Property(x => x.Bairro).IsRequired();
            Property(x => x.Cep).IsRequired();
            Property(x => x.Numero).IsRequired();
        }
    }
}
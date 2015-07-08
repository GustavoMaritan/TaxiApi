using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
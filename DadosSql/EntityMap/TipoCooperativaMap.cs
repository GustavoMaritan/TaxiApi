using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using DadosSql.Entities;

namespace DadosSql.EntityMap
{
    public class TipoCooperativaMap : EntityTypeConfiguration<TipoCooperativa>
    {
        public TipoCooperativaMap()
        {
            HasKey(x => x.Id);
            HasMany(x => x.Cooperativas);
            Property(x => x.Descricao).IsRequired();
        }
    }
}
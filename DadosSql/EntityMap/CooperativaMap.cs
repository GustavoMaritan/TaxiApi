﻿using System.Data.Entity.ModelConfiguration;
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

            HasRequired(c => c.Plano)
                .WithMany(c => c.Cooperativas)
                .HasForeignKey(x => x.PlanoId);

            HasRequired(c => c.TipoCooperativa)
                .WithMany(c => c.Cooperativas)
                .HasForeignKey(x => x.TipoCooperativaId);

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
        }
    }
}

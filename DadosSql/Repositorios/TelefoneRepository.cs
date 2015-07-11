using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DadosSql.Contextos;
using DadosSql.Entidades;

namespace DadosSql.Repositorios
{
    public class TelefoneRepository// : BaseRepository<Telefone>
    {
        public void Put(IList<Telefone> telefones , int copId , Contexto ctx)
        {
            try
            {
                var tels = ctx.DbTelefone.Where(x => x.CoperativaId == copId).ToList();

                foreach (var telefone in tels.Where(telefone => telefones.All(x => x.Id != telefone.Id)))
                    ctx.DbTelefone.Remove(telefone);

                foreach (var telefone in telefones)
                    ctx.DbTelefone.AddOrUpdate(telefone);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

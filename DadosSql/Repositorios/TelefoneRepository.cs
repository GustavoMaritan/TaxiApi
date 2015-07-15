using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DadosSql.Contextos;
using DadosSql.Entities;

namespace DadosSql.Repositorios
{
    public class TelefoneRepository// : BaseRepository<Telefone>
    {
        public void Put(IEnumerable<Telefone> telefones , int copId , Contexto ctx)
        {
            try
            {
                var tels = ctx.Telefone.Where(x => x.CooperativaId == copId).ToList();

                foreach (var telefone in tels.Where(telefone => telefones.All(x => x.Id != telefone.Id)))
                    ctx.Telefone.Remove(telefone);

                foreach (var telefone in telefones)
                    ctx.Telefone.AddOrUpdate(telefone);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DadosSql.Contextos;
using DadosSql.DataModel.Coperativa;
using DadosSql.Entidades;

namespace DadosSql.Repositorios
{
    public class CoperativaRepository
    {
        public List<CoperativaGrid> GetGrid(bool? ativo = null)
        {
            using (var ct = new Contexto())
            {
                var list = ct.DbCoperativa.ToList()
                    .Where(x => x.Ativo == ativo || ativo == null)
                    .Select(x => new CoperativaGrid
                    {
                        Id = x.Id,
                        Descricao = x.Descricao,
                        QtdeTelefones = x.QtdeTelefones,
                        DataVencimento = x.Controles.OrderBy(d => d.DataVencimento).Last().DataVencimento,
                        Recebido = x.Controles.OrderBy(d => d.DataVencimento).Last().Recebido,
                    }).ToList();
                return list;
            }
        }

        public Coperativa Get(int id)
        {
            var ct = new Contexto();
            var cop = ct.DbCoperativa.FirstOrDefault(x => x.Id == id);

            if (cop != null)
            {
                var ctrl = cop.Controles.OrderBy(x => x.DataVencimento).Last();
                cop.Controles.Clear();
                cop.Controles.Add(ctrl);
            }
            return cop;
        }

        public void Put(Coperativa obj)
        {
            using (var ct = new Contexto())
            using (var trans = ct.Database.BeginTransaction())
            {
                try
                {
                    new ControleMensalRepository().Put(obj.Controles.First(), ct);

                    if (obj.Telefones.Any())
                        new TelefoneRepository().Put(obj.Telefones, obj.Id, ct);

                    obj.Controles = null;
                    obj.Telefones = null;

                    ct.DbCoperativa.AddOrUpdate(obj);
                    var a = ct.SaveChanges();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        public void Delete(int id)
        {
            using (var ct = new Contexto())
            {
                var coper = ct.DbCoperativa.FirstOrDefault(x => x.Id == id);

                if (coper == null)
                    return;

                coper.Ativo = false;
                coper.Excluido = true;

                ct.Entry(coper).State = EntityState.Modified;

                ct.SaveChanges();
            }
        }

        public int Post(Coperativa obj)
        {
            using (var ct = new Contexto())
            {
                ct.DbCoperativa.Add(obj);

                return ct.SaveChanges();
            }
        }
    }
}
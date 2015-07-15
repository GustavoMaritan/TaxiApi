using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DadosSql.Contextos;
using DadosSql.DataModel.Coperativa;
using DadosSql.Entities;

namespace DadosSql.Repositorios
{
    public class CoperativaRepository
    {
        public List<CoperativaGrid> GetGrid(bool? ativo = null)
        {
            using (var ct = new Contexto())
            {
                var list = ct.Cooperativa.ToList()
                    .Where(x => x.Ativo == ativo || ativo == null)
                    .Select(x => new CoperativaGrid
                    {
                        Id = x.Id,
                        Descricao = x.Descricao,
                    }).ToList();
                return list;
            }
        }

        public Cooperativa Get(int id)
        {
            var ct = new Contexto();
            var cop = ct.Cooperativa.FirstOrDefault(x => x.Id == id);

            if (cop != null)
            {
                var ctrl = cop.Pagamentos.OrderBy(x => x.DataVencimento).Last();
                cop.Pagamentos.Clear();
                cop.Pagamentos.Add(ctrl);
            }
            return cop;
        }

        public void Put(Cooperativa obj)
        {
            using (var ct = new Contexto())
            using (var trans = ct.Database.BeginTransaction())
            {
                try
                {
                    new ControleMensalRepository().Put(obj.Pagamentos.First(), ct);

                    if (obj.Telefones.Any())
                        new TelefoneRepository().Put(obj.Telefones, obj.Id, ct);

                    obj.Pagamentos = null;
                    obj.Telefones = null;

                    ct.Cooperativa.AddOrUpdate(obj);
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
                var coper = ct.Cooperativa.FirstOrDefault(x => x.Id == id);

                if (coper == null)
                    return;

                coper.Ativo = false;
                coper.Excluido = true;

                ct.Entry(coper).State = EntityState.Modified;

                ct.SaveChanges();
            }
        }

        public int Post(Cooperativa obj)
        {
            using (var ct = new Contexto())
            {
                ct.Cooperativa.Add(obj);

                return ct.SaveChanges();
            }
        }
    }
}
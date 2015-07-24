﻿using System;
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
        public Cooperativa GetLogin(string login, string senha)
        {
            using (var ct = new Contexto())
            {
                var a = ct.Cooperativa
                    .FirstOrDefault(x => x.Login.Equals(login) && x.Senha.Equals(senha));

                if (a == null)
                    return null;
               
                return new Cooperativa
                {
                    Id = a.Id,
                    Descricao = a.Descricao
                };
            }
        }

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
                        DescricaoPlano = x.Plano.Descricao,
                        DataCadastro = x.DataCadastro,
                        DataVencimento = x.Pagamentos.Last(y => y.CooperativaId == x.Id).DataVencimento
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
                    new PagamentoRepository().Put(obj.Pagamentos.First(), ct);

                    if (obj.Telefones.Any())
                        new TelefoneRepository().Put(obj.Telefones, obj.Id, ct);

                    obj.Pagamentos = null;
                    obj.Telefones = null;

                    ct.Cooperativa.AddOrUpdate(obj);
                    ct.SaveChanges();
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
                using (var trans = ct.Database.BeginTransaction())
                {
                    try
                    {
                        obj.DataCadastro = DateTime.Now;

                        obj.Pagamentos[0].Valor = ct.Plano.Find(obj.PlanoId).Preco;

                        ct.Cooperativa.Add(obj);

                        ct.SaveChanges();

                        if (obj.Pagamentos[0].DataPagamento != null)
                            new PagamentoRepository().NewPagamento(obj.Pagamentos[0], ct);

                        trans.Commit();
                        return obj.Id;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
  
            }
        }

        public CooperUsuario GetUsuario(int id)
        {
            using (var ct = new Contexto())
            {
                var cop = ct.Cooperativa.First(x => x.Id == id);

                return new CooperUsuario
                {
                    Id = cop.Id,
                    Descricao = cop.Descricao,
                    QtdeTelefones = cop.Plano.QuantidadeMaximaTelefones,
                    Telefones = cop.Telefones.Select(x => new Telefone
                    {
                        Id = x.Id,
                        Ddd = x.Ddd,
                        Numero = x.Numero,
                        Ramal = x.Ramal,
                        OperadoraId = x.OperadoraId
                    }).ToList()
                };
            }
        }
    }
}
﻿using System.Collections.Generic;
using System.Linq;
using DadosSql.Contextos;
using DadosSql.DataModel.Aplicativo;

namespace DadosSql.Repositorios
{
    public class AplicativoRepository
    {
        public List<CoperativaApp> GetAll()
        {
            using (var ct = new Contexto())
            {
                return ct.Cooperativa.Where(x => x.Ativo)
                    .Select(x => new CoperativaApp
                    {
                        Id = x.Id,
                        Descricao = x.Descricao,
                        Bairro = x.Bairro,
                        Tipo = x.TipoCooperativaId,
                        Telefones = x.Telefones.Select(y => new TelefoneApp
                        {
                            Ddd = y.Ddd,
                            Numero = y.Numero,
                            Operadora = y.Operadora.Nome
                        }).ToList()
                    }).ToList();
            }
        }
    }
}

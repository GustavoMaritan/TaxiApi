using System;
using System.Data.Entity.Migrations;
using DadosSql.Contextos;
using DadosSql.Entidades;

namespace DadosSql.Repositorios
{
    public class ControleMensalRepository : BaseRepository<ControleMensal>
    {
        public void Put(ControleMensal obj , Contexto ctx)
        {
            try
            {
                ctx.DbControleMensal.AddOrUpdate(obj);

                if (!obj.Recebido) 
                    return;

                var controle = new ControleMensal
                {
                    Id = 0,
                    CoperativaId = obj.CoperativaId,
                    DataContrato = obj.DataContrato,
                    DataVencimento = obj.DataVencimento.AddMonths(1),
                    Recebido = false,
                    Valor = obj.Valor
                };
                ctx.DbControleMensal.AddOrUpdate(controle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

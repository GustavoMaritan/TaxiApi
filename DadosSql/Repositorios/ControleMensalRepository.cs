using System;
using System.Data.Entity.Migrations;
using DadosSql.Contextos;
using DadosSql.Entities;

namespace DadosSql.Repositorios
{
    public class ControleMensalRepository //: BaseRepository<ControleMensal>
    {
        public void Put(Pagamento obj , Contexto ctx)
        {
            try
            {
                //ctx.Pagamento.AddOrUpdate(obj);

                //if (!obj.Recebido) 
                //    return;

                //var controle = new Pagamento
                //{
                //    Id = 0,
                //    CooperativaId = obj.CooperativaId,
                //    DataVencimento = obj.DataVencimento.AddMonths(1),
                //    Recebido = false,
                //    Valor = obj.Valor
                //};
                //ctx.Pagamento.AddOrUpdate(controle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

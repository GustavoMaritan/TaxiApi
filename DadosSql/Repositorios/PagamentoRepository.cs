using DadosSql.Contextos;
using DadosSql.Entities;

namespace DadosSql.Repositorios
{
    public class PagamentoRepository
    {
        public void NewPagamento(Pagamento old , Contexto ct)
        {
            ct.Pagamento.Add(new Pagamento
            {
                CooperativaId = old.CooperativaId,
                DataVencimento = old.DataVencimento.AddMonths(1),
                Valor = old.Valor,
            });

            ct.SaveChanges();
        }
    }
}
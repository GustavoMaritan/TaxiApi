using System;

namespace DadosSql.Entities
{
    public class Pagamento : Entity
    {
        public int CooperativaId { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public bool Recebido { get; set; }
        public virtual Cooperativa Cooperativa { get; set; }
    }
}

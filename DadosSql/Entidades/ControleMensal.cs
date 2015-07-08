using System;

namespace DadosSql.Entidades
{
    public class ControleMensal : BaseEntity
    {
        public int CoperativaId { get; set; }
        public DateTime DataContrato { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public bool Recebido { get; set; }

        public Coperativa Coperativa { get; set; }
    }
}

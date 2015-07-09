using System;

namespace DadosSql.DataModel.Coperativa
{
    public class CoperativaGrid
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int QtdeTelefones { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Recebido { get; set; }
    }
}

using System;

namespace DadosSql.DataModel.Coperativa
{
    public class CoperativaGrid
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string DescricaoPlano { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}

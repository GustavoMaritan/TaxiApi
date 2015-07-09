using System.Collections.Generic;

namespace DadosSql.DataModel.Aplicativo
{
    public class CoperativaApp
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Bairro { get; set; }
        public virtual List<TelefoneApp> Telefones { get; set; }
    }
}

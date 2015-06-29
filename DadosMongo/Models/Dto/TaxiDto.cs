using System.Collections.Generic;

namespace DadosMongo.Entidades.EntidadeRetorno
{
    //[Description("Taxi")]
    public class TaxiDto : BaseEntity
    {
        public string Descricao { get; set; }
        public List<TelefoneDto> Telefones { get; set; }
    }
}
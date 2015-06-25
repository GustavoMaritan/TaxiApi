using System.Collections.Generic;

namespace DadosMongo.Entidades.EntidadeRetorno
{
    //[Description("Taxi")]
    public class Taxi : BaseEntity
    {
        public string Descricao { get; set; }
        public List<Telefones> Telefones { get; set; }
    }
}
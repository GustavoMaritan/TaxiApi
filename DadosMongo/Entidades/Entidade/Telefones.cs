using System.ComponentModel;

namespace DadosMongo.Entidades.Entidade
{
    [Description("Taxi3")]
    public class Telefones : BaseEntity
    {
        public short Ddd { get; set; }
        public int Numero { get; set; }
    }
}

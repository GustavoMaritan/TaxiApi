using System.Collections.Generic;

namespace DadosSql.Entities
{
    public class TipoCooperativa : Entity
    {
        public string Descricao { get; set; }
        public virtual IList<Cooperativa> Cooperativas { get; set; }
    }
}

using System.Collections.Generic;

namespace DadosSql.Entities
{
    public class Plano : Entity
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeMaximaTelefones { get; set; }
        public virtual ICollection<Cooperativa> Cooperativas { get; set; }
    }
}
using System.Collections.Generic;

namespace DadosSql.Entities
{
    public class Operadora : Entity
    {
        public Operadora()
        {
            
        }

        public Operadora(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
        public virtual  ICollection<Telefone> Telefones { get; set; } 
    }
}

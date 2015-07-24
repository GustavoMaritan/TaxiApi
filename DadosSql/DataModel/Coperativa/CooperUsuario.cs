using System.Collections.Generic;
using DadosSql.Entities;

namespace DadosSql.DataModel.Coperativa
{
    public class CooperUsuario
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int QtdeTelefones { get; set; }
        public List<Telefone> Telefones { get; set; }
    }
}

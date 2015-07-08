using System;
using System.Collections.Generic;

namespace DadosSql.Entidades
{
    public class Coperativa : BaseEntity
    {
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Senha { get; set; }

        public IList<Telefone> Telefones { get; set; }
        public IList<ControleMensal> Controles { get; set; }
    }
}

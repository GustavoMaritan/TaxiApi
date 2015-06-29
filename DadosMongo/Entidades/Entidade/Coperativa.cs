using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DadosMongo.Entidades.Entidade
{
    [Description("Taxi3")]
    public class Coperativa : BaseEntityManut
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public int QtdeTelefones { get; set; }
        public string NomeFantasia { get; set; }
        public List<Telefones> Telefones { get; set; }

        public bool Pago { get; set; }
        public bool Bloqueado { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
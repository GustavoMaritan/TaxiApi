using System;
using System.Collections.Generic;
using DadosMongo.Entidades.EntidadeRetorno;

namespace DadosMongo.Entidades.EntidadeCrud
{
    public class Usuario : BaseEntity
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public bool Pago { get; set; }
        public int QtdeTelefones { get; set; }

        public string Descricao { get; set; }
        public List<Telefones> Telefones { get; set; }
    }
}

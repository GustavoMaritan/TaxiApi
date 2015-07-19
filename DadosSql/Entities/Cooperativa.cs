using System;
using System.Collections.Generic;

namespace DadosSql.Entities
{
    public class Cooperativa : Entity
    {
        public int PlanoId { get; set; }
        public int TipoCooperativaId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int Cep { get; set; }
        public int Numero { get; set; }
        public virtual Plano Plano { get; set; }
        public virtual TipoCooperativa TipoCooperativa { get; set; }
        public virtual IList<Pagamento> Pagamentos { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}

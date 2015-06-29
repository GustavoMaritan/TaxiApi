using System.Collections.Generic;
using System.Linq;
using DadosMongo.DataModel.Coperativa;
using DadosMongo.Entidades.Entidade;
using MongoDB.Driver.Builders;

namespace DadosMongo.AcessaDados
{
    public class AcessaCoperativa : BaseAcessaDados<Coperativa>
    {
        public new List<ListCoperativa> GetAll()
        {
            return GetCollection().FindAllAs<ListCoperativa>()
                .SetFields(Fields
                    .Exclude("Login")
                    .Exclude("Senha")
                    .Exclude("Cnpj")
                    .Exclude("RazaoSocial")
                    .Exclude("Telefones")
                    .Exclude("Bloqueado")
                    .Exclude("Excluido")
                    .Exclude("UsuarioCad")
                    .Exclude("UsuarioAlt")
                    .Exclude("DataAlt")
                    .Exclude("DataCad"))
                .ToList();
        }
    }
}
/*
   public ObjectId Id { get; set; }
   public string NomeFantasia { get; set; }
   public int QtdeTelefones { get; set; }
   public bool Pago { get; set; }
   public DateTime DataVencimento { get; set; }
 * 
   public string Login { get; set; }
   public string Senha { get; set; }
   public string Cnpj { get; set; }
   public string RazaoSocial { get; set; }
   public List<Telefones> Telefones { get; set; }
   public bool Bloqueado { get; set; }
   public bool Excluido { get; set; }
   public ObjectId UsuarioCad { get; set; }
   public ObjectId? UsuarioAlt { get; set; }
   public DateTime? DataAlt { get; set; }
   public DateTime DataCad { get; set; }
 */
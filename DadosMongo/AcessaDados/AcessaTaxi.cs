using System.Collections.Generic;
using System.Linq;
using DadosMongo.Entidades.EntidadeRetorno;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;

namespace DadosMongo.AcessaDados
{
    public class AcessaTaxi : ConexaoBase<Taxi>
    {
        public List<Taxi> GetAll()
        {
            return GetCollection().FindAllAs<Taxi>()
                .SetFields(Fields
                    .Exclude("Login")
                    .Exclude("Senha")
                    .Exclude("DataCadastro")
                    .Exclude("Cnpj")
                    .Exclude("RazaoSocial")
                    .Exclude("Pago")
                    .Exclude("QtdeTelefones"))
                .ToList();
        }

        public List<Taxi> GetUsuario()
        {
            var a = GetCollection().FindAllAs<BsonDocument>()
                //.SetFields(Fields.Exclude("_id").Exclude("Telefones"))
                .SetFields(Fields.Exclude("_id")
                .Exclude("Descricao").Exclude("Telefones._id"))
                .ToJson();

            //var ab = JsonConvert.DeserializeObject<List<Tes>>(a);
            var ab = JsonConvert.DeserializeObject<List<Xv1>>(a);

            return new List<Taxi>();
        }
    }
    public class Tes
    {
        public string Descricao { get; set; }
    }

    public class Xv1
    {
        public List<Xv> Telefones { get; set; }
    }

    public class Xv
    {
        public int Ddd { get; set; }
        public int Numero { get; set; }
    }
}
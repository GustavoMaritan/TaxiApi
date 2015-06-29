using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;

namespace DadosMongo.AcessaDados
{
    //public class AcessaTaxi : ConexaoBase<Taxi>
    //{
    //    public List<Taxi> GetAll()
    //    {
    //        return GetCollection().FindAllAs<Taxi>()
    //            .SetFields(Fields
    //                .Exclude("Login")
    //                .Exclude("Senha")
    //                .Exclude("DataCadastro")
    //                .Exclude("Cnpj")
    //                .Exclude("RazaoSocial")
    //                .Exclude("Pago")
    //                .Exclude("QtdeTelefones"))
    //            .ToList();
    //    }

    //    //public List<Taxi> GetAtivos()
    //    //{
    //    //    var query = Query.And(
    //    //      Query<Usuario>.EQ(x => x.Pago, false),
    //    //      Query<Usuario>.EQ(x => x.NomeFantasia, null));

    //    //    return GetCollection().FindAs<Taxi>(query)// AllAs<Taxi>()
    //    //         .SetFields(Fields
    //    //            .Exclude("Login")
    //    //            .Exclude("Senha")
    //    //            .Exclude("DataCadastro")
    //    //            .Exclude("Cnpj")
    //    //            .Exclude("RazaoSocial")
    //    //            .Exclude("Pago")
    //    //            .Exclude("QtdeTelefones"))
    //    //        .ToList();
            
    //    //}
    //}
}
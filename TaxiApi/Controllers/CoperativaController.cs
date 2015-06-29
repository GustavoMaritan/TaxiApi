using System;
using System.Web.Http;
using DadosMongo.AcessaDados;
using DadosMongo.Entidades.Entidade;
using MongoDB.Bson;

namespace TaxiApi.Controllers
{
    public class CoperativaController : ApiController
    {
        [HttpGet]
        [Route("api/Coperativa/")]
        public dynamic Get()
        {
            var list = new AcessaCoperativa().GetAll();
            return Json(list);
        }

        [HttpGet]
        [Route("api/Coperativa/{id}")]
        public dynamic Get(string id)
        {
            var cop = new AcessaCoperativa().GetId(new ObjectId(id));
            return Json(cop);
        }

        [HttpPost]
        [Route("api/Coperativa/")]
        public void Post(Coperativa usua)
        {
            usua.DataCad = DateTime.Now;
            usua.UsuarioCad = new ObjectId(usua.UsuarioId);
            var a = new AcessaCoperativa().Insert(usua);
        }
    }

    public class Teste
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Pago { get; set; }
        public string QtdeTelefones { get; set; }
        public string Descricao { get; set; }
    }
}
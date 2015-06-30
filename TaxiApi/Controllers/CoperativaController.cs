using System;
using System.Web.Http;
using DadosMongo.AcessaDados;
using DadosMongo.Entidades.Entidade;
using MongoDB.Bson;

namespace TaxiApi.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class CoperativaController : ApiController
    {
        [HttpGet]
        public dynamic Get()
        {
            var list = new AcessaCoperativa().GetAll();
            return Json(list);
        }

        [HttpGet]
        [Route("{id}")]
        public dynamic Get(string id)
        {
            var cop = new AcessaCoperativa().GetId(new ObjectId(id));
            return Json(cop);
        }

        [HttpPost]
        public IHttpActionResult Post(Coperativa usua)
        {
            usua.DataCad = DateTime.Now;
            usua.UsuarioCad = new ObjectId(usua.UsuarioId);
            var user = new AcessaCoperativa().Insert(usua);
            return Ok(Json(user));
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
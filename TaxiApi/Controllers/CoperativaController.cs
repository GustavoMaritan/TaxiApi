using System;
using System.Web.Http;
using DadosSql.Entidades;
using DadosSql.Repositorios;
using Newtonsoft.Json;

namespace TaxiApi.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class CoperativaController : ApiController
    {
        [HttpGet]
        public dynamic Get()
        {
            var ret1 = new CoperativaRepository().GetGrid();

            return Json(ret1, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpGet]
        public dynamic Get(string id)
        {
            var cop = new CoperativaRepository().Get(int.Parse(id));
            return Json(cop, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpPost]
        public dynamic Post(Coperativa usua)
        {
            usua.DataCadastro = DateTime.Now;
            usua.Controles[0].DataContrato = DateTime.Now;
            var user = new CoperativaRepository().Post(usua);
            return Json(user);
        }

        [HttpPut]
        public dynamic Put(Coperativa usua)
        {
            var user = new CoperativaRepository().Put(usua);

            return user == 1
                ? Json(new {error = ""})
                : Json(new {error = "Erro  ao editar coperativa."});
        }
    }
}
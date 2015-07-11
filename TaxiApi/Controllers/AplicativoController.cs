using System.Configuration;
using System.Web.Http;
using DadosSql.Repositorios;
using Newtonsoft.Json;

namespace TaxiApi.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class AplicativoController : ApiController
    {
        public dynamic Get()
        {
            var ret = new AplicativoRepository().GetAll();

            return Json(ret, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public dynamic Get(string login, string senha)
        {
            return Json(new {nome = "Esteves"});
        }
    }
}
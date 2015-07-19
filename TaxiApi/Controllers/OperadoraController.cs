using System.Web.Http;
using DadosSql.Repositorios;
using Newtonsoft.Json;

namespace TaxiApi.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class OperadoraController : ApiController
    {
        public dynamic Get()
        {
            var ope = new OperadoraRepository().GetAll();

            return Json(ope, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
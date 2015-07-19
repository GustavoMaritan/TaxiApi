using System.Web.Http;
using DadosSql.Repositorios;
using Newtonsoft.Json;

namespace TaxiApi.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class TipoCooperativaController : ApiController
    {
        public dynamic Get()
        {
            var tpCop = new TipoCooperativaRepository().GetAll();

            return Json(tpCop, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
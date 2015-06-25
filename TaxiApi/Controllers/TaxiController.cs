using System.Web.Http;
using DadosMongo.AcessaDados;

namespace TaxiApi.Controllers
{
    public class TaxiController : ApiController
    {
        [HttpGet]
        public dynamic Get()
        {
            var list = new AcessaTaxi().GetAll();

            return Json(list);
        }
    }
}
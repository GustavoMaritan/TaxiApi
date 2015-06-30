using System;
using System.Web.Http;
using DadosMongo.AcessaDados;
using DadosMongo.Entidades.Entidade;

namespace TaxiApi.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        public dynamic Get(string login, string senha)
        {
            var list = new AcessaAdmins().GetAdmLogado(login, senha);

            if (list != null)
                return Json(list);

            return Json(new { error = "Usuário não encontrado." });
        }

        [HttpPost]
        public IHttpActionResult Post(Administrador usua)
        {
            usua.DataCad = DateTime.Now;
            var user = new AcessaAdmins().Insert(usua);
            return Ok(Json(user));
        }
    }
}
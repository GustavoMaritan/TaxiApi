using System;
using System.Web.Http;
using DadosSql.Entities;
using DadosSql.Repositorios;
using Newtonsoft.Json;

namespace TaxiApi.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        public dynamic Get(string login, string senha)
        {
            var repository = new CoperativaRepository();

            var admin = repository.GetLogin(login, senha);

            if (admin != null)
                return Json(admin);

            return Json(new { error = "Usuário não encontrado." });
        }

        [HttpGet]
        public dynamic Get(string id)
        {
            var cop = new CoperativaRepository().GetUsuario(int.Parse(id.Trim()));
            return Json(cop, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpPut]
        public dynamic Put(Cooperativa usua)
        {
            try
            {
                new CoperativaRepository().PutUsuario(usua);
                return Json(new { error = "" });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}
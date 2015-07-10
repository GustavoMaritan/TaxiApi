using System.Web.Http;
using DadosSql.Entidades;
using DadosSql.Repositorios;

namespace TaxiApi.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class AdminController : ApiController
    {
        [HttpGet]
        public dynamic Get(string login, string senha)
        {
            var repository = new AdministradorRepository();

            //var a = repository.Post(new Administrador
            //{
            //    Email = "gustavo@gmail.com",
            //    Login = "gustavo",
            //    Senha = "123456",
            //    Nome = "Gustavo"
            //});

            var admin = repository.AdminLogado(login, senha);

            if (admin != null)
                return Json(admin);

            return Json(new { error = "Usuário não encontrado." });
        }

        [HttpPost]
        public IHttpActionResult Post(Administrador usua)
        {
            var user = new AdministradorRepository().Post(usua);
            return Ok(Json(user));
        }

        public dynamic Get()
        {
            return Json(new {nome = "Esteves"});
        }
    }
}
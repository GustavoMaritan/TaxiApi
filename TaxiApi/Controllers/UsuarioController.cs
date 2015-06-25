using System;
using System.Web.Http;
using DadosMongo.AcessaDados;
using DadosMongo.Entidades.EntidadeCrud;

namespace TaxiApi.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpGet]
        public dynamic Get(string login,string senha)
        {
            var list = new AcessaUsuario()
                .GetUsuarioLogado(login, senha);

            return Json(list);
        }

        [HttpPost]
        public void Post(Usuario usua)
        {
            usua.DataCadastro = DateTime.Now;
            var a = new AcessaUsuario().Insert(usua);
        }

        public void Put()
        {
        }

        public void Delete(int id)
        {
        }
    }
}
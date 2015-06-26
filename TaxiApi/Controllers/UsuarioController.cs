using System;
using System.Collections.Generic;
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
        //[HttpPost]
        //public void Post(Teste usua)
        //{
        //    var l = new List<Usuario>();
        //    foreach (var usuario in usua.Usuario)
        //    {
        //        usuario.DataCadastro = DateTime.Now;
        //        l.Add(usuario);
        //    }
        //    new AcessaUsuario().Insert(l);
        //}

        public void Put()
        {
        }

        public void Delete(int id)
        {
        }
    }

    public class Teste
    {
        public List<Usuario> Usuario { get; set; }
    }
}
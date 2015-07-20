using System;
using System.IO;
using System.Web.Http;
using DadosSql.Entities;
using DadosSql.Repositorios;
using Newtonsoft.Json;

namespace TaxiApi.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class AdminController : ApiController
    {
        [HttpGet]
        public dynamic Get(string login, string senha)
        {
            var repository = new AdministradorRepository();

            var admin = repository.AdminLogado(login, senha);

            if (admin != null)
                return Json(admin);

            return Json(new { error = "Usuário não encontrado." });
        }

        public dynamic Get()
        {
            var admins = new AdministradorRepository().GetAll();

            return Json(admins, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpGet]
        public dynamic Get(string id)
        {
            var cop = new AdministradorRepository().Get(int.Parse(id));

            if (cop.Image != null)
            {
                var uploadPath = AppDomain.CurrentDomain.BaseDirectory + @"\Comum\content\perfil\";
                var caminhoArquivo = Path.Combine(uploadPath, cop.Image);
                if (!File.Exists(caminhoArquivo))
                    cop.Image = null;
            }

            return Json(cop, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpPost]
        public dynamic Post(Administrador usua)
        {
            try
            {
                var user = new AdministradorRepository().Post(usua);
                return Json(new { error = "" });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        [HttpPut]
        public dynamic Put(Administrador usua)
        {
            try
            {
                new AdministradorRepository().Put(usua);
                return Json(new { error = "" });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        [HttpDelete]
        public dynamic Delete(int id)
        {
            try
            {
                new AdministradorRepository().Delete(id);
                return Json(new { error = "" });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}
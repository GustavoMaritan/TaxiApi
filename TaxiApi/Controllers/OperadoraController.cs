using System;
using System.Web.Http;
using DadosSql.Entities;
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

        [HttpGet]
        public dynamic Get(string id)
        {
            var cop = new OperadoraRepository().Get(int.Parse(id));
            return Json(cop, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpPost]
        public dynamic Post(Operadora usua)
        {
            try
            {
                var user = new OperadoraRepository().Post(usua);
                return Json(new { error = "" });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        [HttpPut]
        public dynamic Put(Operadora usua)
        {
            try
            {
                new OperadoraRepository().Put(usua);
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
                new OperadoraRepository().Delete(id);
                return Json(new { error = "" });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}
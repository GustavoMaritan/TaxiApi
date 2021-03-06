﻿using System;
using System.Web.Http;
using DadosSql.Entidades;
using DadosSql.Repositorios;
using Newtonsoft.Json;

namespace TaxiApi.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class CoperativaController : ApiController
    {
        [HttpGet]
        public dynamic Get()
        {
            var ret1 = new CoperativaRepository().GetGrid();

            return Json(ret1, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpGet]
        public dynamic Get(string id)
        {
            var cop = new CoperativaRepository().Get(int.Parse(id));
            return Json(cop, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpPost]
        public dynamic Post(Coperativa usua)
        {
            try
            {
                usua.DataCadastro = DateTime.Now;
                usua.Controles[0].DataContrato = DateTime.Now;
                var user = new CoperativaRepository().Post(usua);
                return Json(new { error = "" });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
      
        }

        [HttpPut]
        public dynamic Put(Coperativa usua)
        {
            try
            {
                new CoperativaRepository().Put(usua);
                return Json(new {error = ""});
            }
            catch (Exception ex)
            {
                return Json(new {error = ex.Message});
            }
        }

        [HttpDelete]
        public dynamic Delete(int id)
        {
            try
            {
                new CoperativaRepository().Delete(id);
                return Json(new {error = ""});
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}
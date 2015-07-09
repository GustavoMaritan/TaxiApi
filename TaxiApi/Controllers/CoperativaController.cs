using System;
using System.Collections.Generic;
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
            //var codCoper = GerarRegistro();
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
            //var cop = new AcessaCoperativa().GetId(new ObjectId(id));
            //return Json(cop);
            return null;
        }

        [HttpPost]
        public IHttpActionResult Post(Coperativa usua)
        {
            //usua.DataCad = DateTime.Now;
            //usua.UsuarioCad = new ObjectId(usua.UsuarioId);
            //var user = new AcessaCoperativa().Insert(usua);
            //return Ok(Json(user));
            return null;
        }

        public int GerarRegistro()
        {
            var a = new Coperativa
            {
                Ativo = true,
                Senha = "123456",
                DataCadastro = DateTime.Now,
                Descricao = "Coperativa3",
                Bairro = "Centro",
                RazaoSocial = "a",
                Numero = 12,
                QtdeTelefones = 5,
                Login = "gus",
                Endereco = "Rua",
                Cnpj = "123",
                Cep = 123,
                Controles = new List<ControleMensal>
                {
                    new ControleMensal
                    {
                        DataContrato = DateTime.Now,
                        DataVencimento = new DateTime(2015,7,25),
                        Recebido = false,
                        Valor = 50
                    }
                },
                Telefones = new List<Telefone>
                {
                    new Telefone
                    {
                        Ddd = 16,
                        Numero = 37231223,
                        Ramal = 44,
                    },
                    new Telefone
                    {
                        Ddd = 16,
                        Numero = 22222222,
                        Ramal = 44,
                    },
                    new Telefone
                    {
                        Ddd = 16,
                        Numero = 33333333,
                        Ramal = 44,
                    },
                }
            };
            return new CoperativaRepository().Post(a);
        }

        public void RemoveAll()
        {
            var ret1 = new TelefoneRepository().DeleteAll();
            var ret2 = new ControleMensalRepository().DeleteAll();
            var ret = new CoperativaRepository().DeleteAll();
        }
    }
}
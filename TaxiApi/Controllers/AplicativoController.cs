using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using DadosSql.Entidades;
using DadosSql.Repositorios;
using Newtonsoft.Json;

namespace TaxiApi.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class AplicativoController : ApiController
    {
        public dynamic Get()
        {
            //var ret = new AplicativoRepository().GetAll();

            var coperativas = new List<Teste>
            {
               #region Dados
		     new Teste
                {
                    Id = 1,
                    Descricao = "Coper1",
                    Bairro = "Centro",
                    Tipo = 1,
                    Telefones = new List<Telefone>
                    {
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                    }
                },
                new Teste
                {
                    Id = 2,
                    Descricao = "Coper2",
                    Bairro = "Estacao",
                    Tipo = 1,
                    Telefones = new List<Telefone>
                    {
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                    }
                },
                new Teste
                {
                    Id = 3,
                    Descricao = "CoperMoto",
                    Bairro = "Estacao",
                    Tipo = 2,
                    Telefones = new List<Telefone>
                    {
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        }
                    }
                },
                new Teste
                {
                    Id = 4,
                    Descricao = "CoperMoto2",
                    Bairro = "Estacao",
                    Tipo = 2,
                    Telefones = new List<Telefone>
                    {
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                    }
                },
                new Teste
                {
                    Id = 5,
                    Descricao = "CoperAll",
                    Bairro = "Estacao",
                    Tipo = 3,
                    Telefones = new List<Telefone>
                    {
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                        new Telefone
                        {
                            CoperativaId = 1,
                            Ddd = 16,
                            Numero = 32143214
                        },
                    }
                }, 
	#endregion
            };
            return Json(coperativas, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public dynamic Get(string login, string senha)
        {
            return Json(new { nome = "Esteves" });
        }
    }

    public class Teste
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Tipo { get; set; }
        public string Bairro { get; set; }

        public List<Telefone> Telefones { get; set; }
    }
}
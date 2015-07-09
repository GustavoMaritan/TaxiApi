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
            #region ☼ Gerar Registro ☼
            //var a = new Coperativa
            //{
            //    Ativo = true,
            //    Senha = "123456",
            //    DataCadastro = DateTime.Now,
            //    Descricao = "Coperativa3",
            //    Bairro = "Centro",
            //    RazaoSocial = "a",
            //    Numero = 12,
            //    QtdeTelefones = 5,
            //    Login = "gus",
            //    Endereco = "Rua",
            //    Cnpj = "123",
            //    Cep = 123,
            //    Controles = new List<ControleMensal>
            //    {
            //        new ControleMensal
            //        {
            //            DataContrato = DateTime.Now,
            //            DataVencimento = DateTime.Now,
            //            Recebido = false,
            //            Valor = 50
            //        }
            //    },
            //    Telefones = new List<Telefone>
            //    {
            //        new Telefone
            //        {
            //            Ddd = 16,
            //            Numero = 37231223,
            //            Ramal = 44,
            //        },
            //        new Telefone
            //        {
            //            Ddd = 16,
            //            Numero = 22222222,
            //            Ramal = 44,
            //        },
            //        new Telefone
            //        {
            //            Ddd = 16,
            //            Numero = 33333333,
            //            Ramal = 44,
            //        },
            //    }
            //};
            //var ret1 = new CoperativaRepository().Post(a); 
            #endregion

            var ret = new CoperativaRepository().GetAll();

            return Json(ret, new JsonSerializerSettings()
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
    }
}
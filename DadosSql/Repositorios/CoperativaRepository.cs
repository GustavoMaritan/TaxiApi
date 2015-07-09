using System.Collections.Generic;
using System.Linq;
using DadosSql.DataModel;
using DadosSql.Entidades;

namespace DadosSql.Repositorios
{
    public class CoperativaRepository : BaseRepository<Coperativa>
    {
        public new List<CoperativaApp> GetAll()
        {
            return Ct.DbCoperativa
                .Select(x => new CoperativaApp
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    Bairro = x.Bairro,
                    Telefones = x.Telefones.Select(y => new TelefoneApp
                    {
                        Ddd = y.Ddd,
                        Numero = y.Numero
                    }).ToList()
                }).ToList();
        }
    }
}

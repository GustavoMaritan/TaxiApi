using System.Collections.Generic;
using System.Linq;
using DadosSql.Contextos;
using DadosSql.DataModel.Coperativa;
using DadosSql.Entidades;

namespace DadosSql.Repositorios
{
    public class CoperativaRepository : BaseRepository<Coperativa>
    {
        public List<CoperativaGrid> GetGrid(bool? ativo = null)
        {
            using (var ct = new Contexto())
            {
                var list = ct.DbCoperativa.ToList()
                    .Where(x => x.Ativo == ativo || ativo == null)
                    .Select(x => new CoperativaGrid
                    {
                        Id = x.Id,
                        Descricao = x.Descricao,
                        QtdeTelefones = x.QtdeTelefones,
                        DataVencimento = x.Controles.OrderBy(d => d.DataVencimento).Last().DataVencimento,
                        Recebido = x.Controles.OrderBy(d => d.DataVencimento).Last().Recebido,
                    }).ToList();
                return list;
            }
        }
    }
}
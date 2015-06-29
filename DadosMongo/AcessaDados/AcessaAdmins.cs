using DadosMongo.Entidades.Entidade;
using MongoDB.Driver.Builders;

namespace DadosMongo.AcessaDados
{
    public class AcessaAdmins : BaseAcessaDados<Administrador>
    {
        public Administrador GetAdmLogado(string login, string senha)
        {
            var query = Query.And(
                Query<Administrador>.EQ(x => x.Login, login),
                Query<Administrador>.EQ(x => x.Senha, senha));
            return GetCollection().FindOneAs<Administrador>(query);
        }
    }
}

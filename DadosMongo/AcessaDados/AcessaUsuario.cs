using DadosMongo.Entidades.EntidadeCrud;
using MongoDB.Driver.Builders;

namespace DadosMongo.AcessaDados
{
    public class AcessaUsuario : BaseAcessaDados<Usuario>
    {
        public Usuario GetUsuarioLogado(string login , string senha)
        {
            var query = Query.And(
                Query<Usuario>.EQ(x => x.Login, login),
                Query<Usuario>.EQ(x => x.Senha, senha));
            return GetCollection().FindOneAs<Usuario>(query);
        }
    }
}

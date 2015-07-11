using System.Linq;
using DadosSql.Contextos;
using DadosSql.Entidades;

namespace DadosSql.Repositorios
{
    public class AdministradorRepository : BaseRepository<Administrador>
    {
        public Administrador AdminLogado(string login, string senha)
        {
            using (var ct = new Contexto())
            {
                var teste = ct.DbAdministrador
                     .FirstOrDefault(x => x.Login.Equals(login) && x.Senha.Equals(senha));

                return teste;
            }
        }
    }
}

using System.ComponentModel;

namespace DadosMongo.Entidades.Entidade
{
    [Description("Administradores")]
    public class Administrador : BaseEntity
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
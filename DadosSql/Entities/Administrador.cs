namespace DadosSql.Entities
{
    public class Administrador : Entity
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
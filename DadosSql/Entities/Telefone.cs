namespace DadosSql.Entities
{
    public class Telefone : Entity
    {
        public int OperadoraId { get; set; }
        public int CooperativaId { get; set; }
        public short Ddd { get; set; }
        public int Numero { get; set; }
        public short? Ramal { get; set; }
        public virtual Cooperativa Cooperativa { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}

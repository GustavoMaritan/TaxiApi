namespace DadosSql.Entidades
{
    public class Telefone : BaseEntity
    {
        public int CoperativaId { get; set; }
        public short Ddd { get; set; }
        public int Numero { get; set; }
        public short? Ramal { get; set; }

        public virtual Coperativa Coperativa { get; set; }
    }
}

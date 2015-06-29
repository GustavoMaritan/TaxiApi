using System;
using MongoDB.Bson;

namespace DadosMongo.DataModel.Coperativa
{
    public class ListCoperativa
    {
        public ObjectId Id { get; set; }
        public string NomeFantasia { get; set; }
        public bool Pago { get; set; }
        public int QtdeTelefones { get; set; }
        public DateTime DataVencimento{ get; set; }
    }
}

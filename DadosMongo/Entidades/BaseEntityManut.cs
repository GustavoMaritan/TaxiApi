using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DadosMongo.Entidades
{
    public class BaseEntityManut : BaseEntity
    {
        public ObjectId UsuarioCad { get; set; }
        public ObjectId? UsuarioAlt { get; set; }
        public DateTime? DataAlt { get; set; }

        [BsonIgnore]
        public string UsuarioId { get; set; }
        [BsonIgnore]
        public string UsuarioAltId { get; set; }
    }
}

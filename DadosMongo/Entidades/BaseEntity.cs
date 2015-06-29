using System;
using MongoDB.Bson;

namespace DadosMongo.Entidades
{
    public class BaseEntity
    {
        public ObjectId Id { get; set; }

        public DateTime DataCad { get; set; }
    }
}

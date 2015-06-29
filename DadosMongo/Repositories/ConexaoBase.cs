using System.Configuration;
using DadosMongo.Entidades;
using MongoDB.Driver;

namespace DadosMongo.AcessaDados
{
    public class ConexaoBase<T> where T : BaseEntity
    {
        private readonly MongoCollection _collection;

        public ConexaoBase()
        {
            var server = new MongoClient(ConfigurationManager.AppSettings["LocalBd"]).GetServer();

            _collection = server
                .GetDatabase(ConfigurationManager.AppSettings["BdName"])
                .GetCollection("Taxi2"); //typeof(T).GetDescription());
        }

        public MongoCollection GetCollection()
        {
            return _collection;
        }
    }
}

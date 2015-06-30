using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DadosMongo.Entidades;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace DadosMongo.AcessaDados
{
    public class BaseAcessaDados<T> : ConexaoBase<T> where T : BaseEntity
    {
        public T Insert(T entidade)
        {
            GetCollection().Insert(entidade);
            return entidade;
        }

        public void Insert(List<T> entidades)
        {
            GetCollection().InsertBatch<T>(entidades);
        }

        public T Updade(T entidade)
        {
            GetCollection().Save(entidade);
            return entidade;
        }

        public void Update(List<T> entities)
        {
            foreach (var entity in entities)
                GetCollection().Save<T>(entity);
        }

        public void Delete(ObjectId id)
        {
            GetCollection().Remove(Query.EQ("_id", id));
        }

        public void DeleteAll()
        {
            GetCollection().RemoveAll();
        }

        public T GetId(ObjectId id)
        {
            var query = Query<T>.EQ(e => e.Id, id);
            return GetCollection().FindOneAs<T>(query);
        }

        public T GetFiltro(Expression<Func<T, object>> expressao, object value)
        {
            var query = Query<T>.EQ(expressao, value);
            return GetCollection().FindOneAs<T>(query);
        }

        public virtual List<T> GetAll()
        {
            return GetCollection().FindAllAs<T>().ToList();
        }
    }
}

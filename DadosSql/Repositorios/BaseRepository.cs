using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadosSql.Entidades;

namespace DadosSql.Repositorios
{
    public class BaseRepository<T> where T : BaseEntity
    {
        public Contexto.Contexto Ct = new Contexto.Contexto();

        public virtual int Post(T obj)
        {
            Ct.Set<T>().Add(obj);

            return Ct.SaveChanges();
        }

        public virtual int Put(T obj)
        {
            Ct.Entry(obj).State = EntityState.Modified;

            return Ct.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return Ct.Set<T>().ToList();
        }

        public virtual T Get(int key)
        {
            return Ct.Set<T>().Find(key);
        }

        public virtual int Delete(int credId)
        {
            var cred = Ct.Set<T>().Find(credId);

            if (cred == null) return 0;

            Ct.Set<T>().Remove(cred);

            return Ct.SaveChanges();
        }

        public virtual int DeleteAll()
        {
            var cred = Ct.Set<T>().ToList();

            foreach (var obj in cred)
                Ct.Set<T>().Remove(obj);

            return Ct.SaveChanges();
        }
    }
}

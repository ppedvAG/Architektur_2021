using ppedv.Cooky.Model;
using ppedv.Cooky.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.Cooky.Data.EFCore
{
    public class EfCoreRepository : IRepository
    {
        CookyEfContext context = new CookyEfContext();

        public void Add<T>(T entity) where T : Entity
        {
            //if (typeof(T) == typeof(Mixen))
            //    context.Mixen.Add(entity as Mixen);
            context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public void SaveAll()
        {
            context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            context.Set<T>().Update(entity);
        }
    }
}

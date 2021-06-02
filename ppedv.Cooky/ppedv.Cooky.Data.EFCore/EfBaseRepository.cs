using ppedv.Cooky.Model;
using ppedv.Cooky.Model.Contracts;
using System.Linq;

namespace ppedv.Cooky.Data.EFCore
{
    internal class EfBaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected CookyEfContext context;
        internal EfBaseRepository(CookyEfContext context)
        {
            this.context = context;
        }

        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);

        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);

        }

        public IQueryable<T> Query()
        {
            return context.Set<T>();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }


}

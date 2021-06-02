using ppedv.Cooky.Model;
using ppedv.Cooky.Model.Contracts;

namespace ppedv.Cooky.Data.EFCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        CookyEfContext context = new CookyEfContext();

        public IRezeptRepository RezeptRepository { get => new EfRezeptRepository(context); }

        public IBaseRepository<T> GetRepo<T>() where T : Entity
        {
            return new EfBaseRepository<T>(context);
        }

        public void SaveAll()
        {
            context.SaveChanges();
        }
    }


}

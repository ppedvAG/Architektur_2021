using ppedv.Cooky.Model;
using ppedv.Cooky.Model.Contracts;
using System.Linq;

namespace ppedv.Cooky.Logic
{
    public class Core
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public RezeptService RezeptService { get => new RezeptService(UnitOfWork); }

        public Core(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        public Core() : this(new Data.EFCore.EfUnitOfWork())
        { }


    }
}

using ppedv.Cooky.Model;
using ppedv.Cooky.Model.Contracts;
using System.Linq;

namespace ppedv.Cooky.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repository)
        {
            Repository = repository;
        }

        public Core() : this(new Data.EFCore.EfCoreRepository())
        { }

        public int CountRezepteInDb()
        {
            return Repository.GetAll<Rezept>().Count();
        }
    }
}

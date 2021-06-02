using ppedv.Cooky.Model;
using ppedv.Cooky.Model.Contracts;
using System.Collections.Generic;

namespace ppedv.Cooky.Data.EFCore
{
    internal class EfRezeptRepository : EfBaseRepository<Rezept>, IRezeptRepository
    {
        public EfRezeptRepository(CookyEfContext context) : base(context)
        { }

        public IEnumerable<Rezept> GetRezeptByStoredProc()
        {
            context.Database.BeginTransaction();
            //todo db operationen
            return null;
        }

        public override void Add(Rezept entity)
        {
            base.Add(entity);

        }
    }


}

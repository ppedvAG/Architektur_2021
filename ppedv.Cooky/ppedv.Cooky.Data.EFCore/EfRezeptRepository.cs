using Microsoft.EntityFrameworkCore;
using ppedv.Cooky.Model;
using ppedv.Cooky.Model.Contracts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ppedv.Cooky.Data.EFCore
{
    internal class EfRezeptRepository : EfBaseRepository<Rezept>, IRezeptRepository
    {
        public EfRezeptRepository(CookyEfContext context) : base(context)
        { }

        public IEnumerable<Rezept> GetAllRezepteWithZuaten()
        {
            var query = context.Rezepte.Include(x => x.Schritte).ThenInclude(x => (x.Schritt as ZutatHinzugeben).Zutat);
            Debug.WriteLine(query.ToQueryString());

            return query;
        }

        public override void Add(Rezept entity)
        {
            base.Add(entity);

        }
    }


}

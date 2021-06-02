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
            return Repository.Query<Rezept>().Count();
        }

        public double CalcKCalOfRezept(Rezept rezept)
        {
            return rezept.Schritte.Where(x => x.Schritt is ZutatHinzugeben).Sum(x => ((ZutatHinzugeben)x.Schritt).Zutat.KCalPro100G);
        }

        public Rezept GetRezptWithMostKCal()
        {
            return Repository.Query<Rezept>().OrderBy(x => CalcKCalOfRezept(x)).FirstOrDefault();
        }
    }
}

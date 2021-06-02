using ppedv.Cooky.Model;
using ppedv.Cooky.Model.Contracts;
using System.Linq;

namespace ppedv.Cooky.Logic
{
    public class RezeptService
    {
        public IUnitOfWork UnitOfWork { get; }

        public RezeptService(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        public int CountRezepteInDb()
        {
            return UnitOfWork.RezeptRepository.Query().Count();
        }

        public double CalcKCalOfRezept(Rezept rezept)
        {
            return rezept.Schritte.Where(x => x.Schritt is ZutatHinzugeben).Sum(x => ((ZutatHinzugeben)x.Schritt).Zutat.KCalPro100G);
        }

        public Rezept GetRezeptWithMostKCal()
        {
            return UnitOfWork.RezeptRepository.Query().OrderByDescending(x => CalcKCalOfRezept(x)).FirstOrDefault();
        }
    }
}

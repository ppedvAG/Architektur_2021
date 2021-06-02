using ppedv.Cooky.Model;
using ppedv.Cooky.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Cooky.Logic.Tests
{
    class TestUnitOfWork : IUnitOfWork
    {
        public IRezeptRepository RezeptRepository => new TestRezeptRepository();

        public IBaseRepository<T> GetRepo<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }
    }

    class TestRezeptRepository : IRezeptRepository
    {
        public void Add(Rezept entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Rezept entity)
        {
            throw new NotImplementedException();
        }

        public Rezept GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rezept> GetRezeptByStoredProc()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Rezept> Query()
        {
            var z1 = new Zutat() { KCalPro100G = 12 };
            var z2 = new Zutat() { KCalPro100G = 14 };
            var sz1 = new ZutatHinzugeben() { Zutat = z1 };
            var sz2 = new ZutatHinzugeben() { Zutat = z2 };

            var rez1 = new Rezept() { Name = "R1" };
            rez1.Schritte.Add(new Schritte() { Schritt = sz1 });
            rez1.Schritte.Add(new Schritte() { Schritt = sz2 });

            var rez2 = new Rezept() { Name = "R2" };
            rez2.Schritte.Add(new Schritte() { Schritt = sz1 });
            rez2.Schritte.Add(new Schritte() { Schritt = sz2 });
            rez2.Schritte.Add(new Schritte() { Schritt = sz2 });

            return new[] { rez1, rez2 }.AsQueryable<Rezept>();
        }


        public void Update(Rezept entity)
        {
            throw new NotImplementedException();
        }
    }


}

using ppedv.Cooky.Model;
using ppedv.Cooky.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Cooky.Logic.Tests
{
    class TestRepository : IRepository
    {
        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            if (typeof(T) == typeof(Rezept))
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

                return new[] { rez1, rez2 }.AsQueryable<Rezept>().Cast<T>();
            }

            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}

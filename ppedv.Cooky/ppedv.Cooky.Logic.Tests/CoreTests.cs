using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Cooky.Model;
using ppedv.Cooky.Model.Contracts;
using System.Linq;

namespace ppedv.Cooky.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_CalcKCalOfRezept_No_zutaten()
        {
            var core = new Core(null);
            var rez = new Rezept();

            var result = core.CalcKCalOfRezept(rez);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Core_CalcKCalOfRezept_one_rezept_with_two_zutaten()
        {
            var core = new Core(null);
            var z1 = new Zutat() { KCalPro100G = 12 };
            var z2 = new Zutat() { KCalPro100G = 14 };
            var sz1 = new ZutatHinzugeben() { Zutat = z1 };
            var sz2 = new ZutatHinzugeben() { Zutat = z2 };

            var rez = new Rezept();
            rez.Schritte.Add(new Schritte() { Schritt = sz1 });
            rez.Schritte.Add(new Schritte() { Schritt = sz2 });

            var result = core.CalcKCalOfRezept(rez);

            Assert.AreEqual(26, result);
        }

        [TestMethod]
        public void Core_GetRezeptWithMostKCal_two_rezepte_results_r2()
        {
            var core = new Core(new TestRepository());

            var result = core.GetRezeptWithMostKCal();

            Assert.AreEqual("R2", result.Name);
        }

        [TestMethod]
        public void Core_GetRezeptWithMostKCal_no_rezepte()
        {
            var mock = new Mock<IRepository>();

            var core = new Core(mock.Object);

            var result = core.GetRezeptWithMostKCal();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Core_GetRezeptWithMostKCal_two_rezepte_results_r2_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Rezept>()).Returns(() =>
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
              });
            var core = new Core(mock.Object);

            var result = core.GetRezeptWithMostKCal();

            Assert.AreEqual("R2", result.Name);
        }
    }
}

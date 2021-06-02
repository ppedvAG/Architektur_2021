using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Cooky.Model;

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
    }
}

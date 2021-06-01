using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Cooky.Model;

namespace ppedv.Cooky.Data.EFCore.Tests
{
    [TestClass]
    public class CookyEfContextTest
    {
        [TestMethod]
        public void CookyEfContext_can_create_db()
        {
            var con = new CookyEfContext();
            con.Database.EnsureDeleted();
            con.Database.EnsureCreated();
        }

        [TestMethod]
        public void CookyEfContext_can_add_Zutat()
        {
            var con = new CookyEfContext();
            var zutat = new Zutat() { Name = "Z1", KCalPro100G = 333, MengenEinheit = MengenEinheit.Prise };

            con.Zutaten.Add(zutat);
            int affectedRow = con.SaveChanges();

            Assert.AreEqual(1, affectedRow);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}

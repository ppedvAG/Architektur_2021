using AutoFixture;
using AutoFixture.Kernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Cooky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            using (var con = new CookyEfContext())
            {
                var zutat = new Zutat() { Name = "Z1", KCalPro100G = 333, MengenEinheit = MengenEinheit.Prise };

                con.Zutaten.Add(zutat);
                int affectedRow = con.SaveChanges();

                Assert.AreEqual(1, affectedRow);
            }
        }

        [TestMethod]
        public void CookyEfContext_can_CRUD_Zutat()
        {
            var zName = $"Zutat_{Guid.NewGuid()}";
            var zName2 = $"ZutatNEU_{Guid.NewGuid()}";
            var zutat = new Zutat() { Name = zName, KCalPro100G = 333, MengenEinheit = MengenEinheit.Prise };

            //CREATE
            using (var con = new CookyEfContext())
            {
                con.Zutaten.Add(zutat);
                con.SaveChanges();
            } //con.Dispose(); 

            using (var con = new CookyEfContext())
            {
                //READ
                var loaded = con.Zutaten.FirstOrDefault(x => x.Id == zutat.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(zutat.Name, loaded.Name);

                //UPDATE
                loaded.Name = zName2;
                con.SaveChanges();
            }

            using (var con = new CookyEfContext())
            {
                //check UPDATE
                var loaded = con.Zutaten.FirstOrDefault(x => x.Id == zutat.Id);
                Assert.AreEqual(zName2, loaded.Name);

                //DELETE
                con.Zutaten.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new CookyEfContext())
            {
                //check DELETE
                var loaded = con.Zutaten.FirstOrDefault(x => x.Id == zutat.Id);
                Assert.IsNull(loaded);
            }

        }

        [TestMethod]
        public void CookyEfContext_can_CR_Zutat_AutoFix()
        {
            var fix = new Fixture();

            fix.Behaviors.Add(new OmitOnRecursionBehavior());

            fix.Customizations.Add(new TypeRelay(typeof(ppedv.Cooky.Model.Schritt), typeof(ZutatHinzugeben)));
            fix.Customizations.Add(new PropertyNameOmitter("Id"));

            var zutat = fix.Build<Zutat>().Create();

            using (var con = new CookyEfContext())
            {
                con.Zutaten.Add(zutat);
                con.SaveChanges();
            }
        }
    }

    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}

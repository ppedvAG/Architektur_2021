using ppedv.Cooky.Logic;
using ppedv.Cooky.Model;
using System;
using System.Linq;

namespace ppedv.Cooky.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Cooky v0.1 ***");

            var core = new Core();
            Console.WriteLine($"Rezepte in DB: {core.CountRezepteInDb()}");
            foreach (var rez in core.UnitOfWork.RezeptRepository.Query().Where(x => x.Name.StartsWith("N") && x.Created.Year > 1000).ToList())
            {
                Console.WriteLine($"{rez.Name}");

                foreach (var sch in rez.Schritte.OrderBy(x => x.Position))
                {
                    Console.WriteLine($"\t{sch.Position} {sch.Schritt.Beschreibung}");
                    if (sch.Schritt is ZutatHinzugeben zh)
                        zh.Zutat.KCalPro100G += 1;
                }
            }
            core.UnitOfWork.SaveAll();

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}

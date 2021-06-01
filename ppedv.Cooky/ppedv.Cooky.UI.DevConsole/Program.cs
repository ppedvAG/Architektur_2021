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
            foreach (var rez in core.Repository.Query<Rezept>().Where(x => x.Name.StartsWith("N") && x.Created.Year > 1000))
            {
                Console.WriteLine($"{rez.Name}");
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}

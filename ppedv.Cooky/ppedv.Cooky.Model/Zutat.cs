using System.Collections.Generic;

namespace ppedv.Cooky.Model
{
    public class Zutat : Entity
    {
        public string Name { get; set; }
        public int KCalPro100G { get; set; }
        public MengenEinheit MengenEinheit { get; set; }

        public virtual ICollection<ZutatHinzugeben> Hinzugegeben { get; set; } = new HashSet<ZutatHinzugeben>();
    }

    public enum MengenEinheit
    {
        g,
        Kg,
        mg,
        Teelöffel,
        Prise,
        Schubs,
        Stück,
        Liter,
        ml
    }

}

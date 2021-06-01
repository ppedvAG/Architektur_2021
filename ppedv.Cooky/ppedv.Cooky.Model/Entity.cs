using System;
using System.Collections.Generic;

namespace ppedv.Cooky.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
    }

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


    public class Rezept : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Schritte> Schritte { get; set; } = new HashSet<Schritte>();

    }

    public class Schritte : Entity
    {
        public int Position { get; set; }
        public virtual Rezept Rezept { get; set; }
        public virtual Schritt Schritt{ get; set; }
    }

    public abstract class Schritt : Entity
    {
        public string Beschreibung { get; set; }
        public virtual ICollection<Schritte> Schritte { get; set; } = new HashSet<Schritte>();

    }

    public class ZutatHinzugeben : Schritt
    {
        public int Menge { get; set; }

        public virtual Zutat Zutat { get; set; }
    }

    public class Mixen : Schritt
    {
        public string Geraet { get; set; }
        public int DauerInSekunden { get; set; }
        public int Geschwindigkeit { get; set; }
    }

    public class Erhitzen : Schritt
    {
        public string Geraet { get; set; }
        public int DauerInSekunden { get; set; }
        public int Temperatur { get; set; }
    }



}

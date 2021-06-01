using System;

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
    }

    public class Schritte : Entity
    {
        public int Position { get; set; }
    }

    public abstract class Schritt : Entity
    {
        public string Beschreibung { get; set; }
    }

    public class ZutatHinzugeben : Schritt
    {
        public int Menge { get; set; }
    }

    public class Mixen : Schritt
    {
        public string Geraet { get; set; }
        public int DauerInSekunden { get; set; }
        public int Geschwindigkeit { get; set; }
    }

    public class Erhitzen:Schritt
    {
        public string Geraet { get; set; }
        public int DauerInSekunden { get; set; }
        public int Temperatur { get; set; }
    }



}

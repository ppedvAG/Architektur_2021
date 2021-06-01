namespace ppedv.Cooky.Model
{
    public class ZutatHinzugeben : Schritt
    {
        public int Menge { get; set; }

        public virtual Zutat Zutat { get; set; }
    }



}

namespace ppedv.Cooky.Model
{
    public class Schritte : Entity
    {
        public int Position { get; set; }
        public virtual Rezept Rezept { get; set; }
        public virtual Schritt Schritt{ get; set; }
    }



}

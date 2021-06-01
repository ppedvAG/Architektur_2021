using System.Collections.Generic;

namespace ppedv.Cooky.Model
{
    public abstract class Schritt : Entity
    {
        public string Beschreibung { get; set; }
        public virtual ICollection<Schritte> Schritte { get; set; } = new HashSet<Schritte>();

    }



}

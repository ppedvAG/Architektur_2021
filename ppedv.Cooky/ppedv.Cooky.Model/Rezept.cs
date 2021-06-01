using System.Collections.Generic;

namespace ppedv.Cooky.Model
{
    public class Rezept : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Schritte> Schritte { get; set; } = new HashSet<Schritte>();
    }
}

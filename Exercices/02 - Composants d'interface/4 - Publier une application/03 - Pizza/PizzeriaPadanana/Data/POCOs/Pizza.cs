using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    public partial class Pizza
    {
        public Pizza()
        {
            Lignescommandes = new HashSet<Lignescommande>();
        }

        public int IdPizza { get; set; }
        public int IdTaillePizza { get; set; }
        public int IdTypePizza { get; set; }
        public bool? Actif { get; set; }

        public virtual Taillepizza IdTaillePizzaNavigation { get; set; }
        public virtual Typepizza IdTypePizzaNavigation { get; set; }
        public virtual ICollection<Lignescommande> Lignescommandes { get; set; }
    }
}

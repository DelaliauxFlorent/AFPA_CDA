using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    public partial class Menu
    {
        public Menu()
        {
            Itemsmenus = new HashSet<Itemsmenu>();
            Lignescommandes = new HashSet<Lignescommande>();
        }

        public int IdMenu { get; set; }
        public string NomMenu { get; set; }
        public decimal ReductionMenu { get; set; }
        public string ImageMenu { get; set; }
        public int IdTaillePizza { get; set; }
        public bool? Actif { get; set; }

        public virtual Taillepizza IdTaillePizzaNavigation { get; set; }
        public virtual ICollection<Itemsmenu> Itemsmenus { get; set; }
        public virtual ICollection<Lignescommande> Lignescommandes { get; set; }
    }
}

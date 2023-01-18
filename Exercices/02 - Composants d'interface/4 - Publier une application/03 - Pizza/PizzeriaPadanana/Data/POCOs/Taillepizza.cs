using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    public partial class Taillepizza
    {
        public Taillepizza()
        {
            Menus = new HashSet<Menu>();
            Pizzas = new HashSet<Pizza>();
        }

        public int IdTaillePizza { get; set; }
        public string ValeurTaillePizza { get; set; }
        public decimal MultiplicateurPrixPizza { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}

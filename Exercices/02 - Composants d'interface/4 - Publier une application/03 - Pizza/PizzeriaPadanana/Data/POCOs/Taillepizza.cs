using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    /// <summary>
    /// Classe correspondante à la table TaillePizzas
    /// </summary>
    public partial class Taillepizza
    {
        /// <summary>
        /// Constructeur (pour les listes)
        /// </summary>
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

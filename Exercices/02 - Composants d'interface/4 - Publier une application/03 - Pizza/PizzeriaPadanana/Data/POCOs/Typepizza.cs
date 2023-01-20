using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    /// <summary>
    /// Classe correspondante à la table TypePizzas
    /// </summary>
    public partial class Typepizza
    {
        /// <summary>
        /// Constructeur (pour les listes)
        /// </summary>
        public Typepizza()
        {
            Compositions = new HashSet<Composition>();
            Itemsmenus = new HashSet<Itemsmenu>();
            Pizzas = new HashSet<Pizza>();
        }

        public int IdTypePizza { get; set; }
        public string NomTypePizza { get; set; }
        public decimal PrixBaseTypePizza { get; set; }
        public string ImagePizza { get; set; }
        public bool? Actif { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }
        public virtual ICollection<Itemsmenu> Itemsmenus { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}

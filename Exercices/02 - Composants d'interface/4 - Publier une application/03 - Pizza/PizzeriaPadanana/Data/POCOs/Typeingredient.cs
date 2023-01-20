using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    /// <summary>
    /// Classe correspondante à la table TypeIngredients
    /// </summary>
    public partial class Typeingredient
    {
        /// <summary>
        /// Constructeur (pour la liste)
        /// </summary>
        public Typeingredient()
        {
            Ingredients = new HashSet<Ingredient>();
        }
        public int IdTypeIngredient { get; set; }
        public string NomTypeIngredient { get; set; }
        public decimal PrixTypeIngredient { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}

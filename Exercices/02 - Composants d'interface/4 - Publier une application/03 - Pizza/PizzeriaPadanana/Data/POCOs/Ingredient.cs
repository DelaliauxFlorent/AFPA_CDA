using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    /// <summary>
    /// Classe correspondante à la table Ingredients
    /// </summary>
    public partial class Ingredient
    {
        /// <summary>
        /// Constructeur (pour la liste)
        /// </summary>
        public Ingredient()
        {
            Compositions = new HashSet<Composition>();
        }

        public int IdIngredient { get; set; }
        public string NomIngredient { get; set; }
        public string ImageIngredient { get; set; }
        public bool? Actif { get; set; }
        public int IdTypeIngredient { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }
        public virtual Typeingredient IdTypeIngredientNavigation { get; set; }
    }
}

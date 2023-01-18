using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    public partial class Typeingredient
    {
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

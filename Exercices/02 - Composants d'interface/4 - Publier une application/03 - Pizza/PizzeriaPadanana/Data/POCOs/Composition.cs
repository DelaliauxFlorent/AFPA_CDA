﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    /// <summary>
    /// Classe correspondante à la table Compositions
    /// </summary>
    public partial class Composition
    {
        public int IdCompositions { get; set; }
        public int? IdTypePizza { get; set; }
        public int? IdIngredient { get; set; }

        public virtual Ingredient IdIngredientNavigation { get; set; }
        public virtual Typepizza IdTypePizzaNavigation { get; set; }
    }
}

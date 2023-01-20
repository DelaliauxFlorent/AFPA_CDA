using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.DTOs
{
    /// <summary>
    /// DTO pour les types d'ingrédients
    /// </summary>
    public class TypeingredientDTO
    {
        public int IdTypeIngredient { get; set; }
        public string NomTypeIngredient { get; set; }
        public decimal PrixTypeIngredient { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.DTOs
{
    /// <summary>
    /// DTO Basique
    /// </summary>
    public class IngredientDTO
    {

        public int IdIngredient { get; set; }
        public string NomIngredient { get; set; }
        public string ImageIngredient { get; set; }
        public bool? Actif { get; set; }
        public int IdTypeIngredient { get; set; }

    }

    /// <summary>
    /// DTO pour listing
    /// </summary>
    public class IngredientDTOAvecType
    {
        public int IdIngredient { get; set; }
        public string NomIngredient { get; set; }
        public string ImageIngredient { get; set; }
        public bool? Actif { get; set; }
        public int IdTypeIngredient { get; set; }
        public string NomTypeIngredient { get; set; }
        public float Prix { get; set; }

        public virtual TypeingredientDTO IdTypeIngredientNavigation { get; set; }
    }
}

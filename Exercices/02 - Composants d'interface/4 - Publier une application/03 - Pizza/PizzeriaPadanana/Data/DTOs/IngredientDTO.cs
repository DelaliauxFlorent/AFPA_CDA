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
        //public IngredientDTO()
        //{
        //    Compositions = new HashSet<CompositionDTO>();
        //}

        public int IdIngredient { get; set; }
        public string NomIngredient { get; set; }
        public string ImageIngredient { get; set; }
        public bool? Actif { get; set; }
        public int IdTypeIngredient { get; set; }

        //public virtual ICollection<CompositionDTO> Compositions { get; set; }
        //public virtual TypeingredientDTO IdTypeIngredientNavigation { get; set; }
    }

    /// <summary>
    ///
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

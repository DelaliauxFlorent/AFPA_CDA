using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.DTOs
{
    class TypepizzaDTO
    {
        //public TypepizzaDTO()
        //{
        //    Compositions = new HashSet<CompositionDTO>();
        //}

        public int IdTypePizza { get; set; }
        public string NomTypePizza { get; set; }
        public decimal PrixBaseTypePizza { get; set; }
        public string ImagePizza { get; set; }
        public bool? Actif { get; set; }

        //public virtual ICollection<Composition> Compositions { get; set; }
    }
}

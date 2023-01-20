using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.DTOs
{
    /// <summary>
    /// DTO pour les types de pizza
    /// </summary>
    class TypepizzaDTO
    {
        public int IdTypePizza { get; set; }
        public string NomTypePizza { get; set; }
        public decimal PrixBaseTypePizza { get; set; }
        public string ImagePizza { get; set; }
        public bool? Actif { get; set; }

    }
}

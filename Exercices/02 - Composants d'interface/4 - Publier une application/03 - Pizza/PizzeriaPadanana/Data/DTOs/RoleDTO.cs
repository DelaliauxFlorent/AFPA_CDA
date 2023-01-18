using PizzeriaPadanana.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaPadanana.Data.DTOs
{
    class RoleDTO
    {
        public string NomRole { get; set; }
        public int? NiveauAcreditation { get; set; }

        public virtual Compte Compte { get; set; }
    }

    class RoleDTO_Simple
    {
        public string NomRole { get; set; }
        public int? NiveauAcreditation { get; set; }
    }
}

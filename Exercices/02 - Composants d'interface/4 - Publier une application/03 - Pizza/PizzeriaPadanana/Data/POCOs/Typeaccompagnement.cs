using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    public partial class Typeaccompagnement
    {
        public Typeaccompagnement()
        {
            Accompagnements = new HashSet<Accompagnement>();
        }

        public int IdTypeAccompagnement { get; set; }
        public string NomTypeAccompagnement { get; set; }
        public bool? Actif { get; set; }

        public virtual ICollection<Accompagnement> Accompagnements { get; set; }
    }
}

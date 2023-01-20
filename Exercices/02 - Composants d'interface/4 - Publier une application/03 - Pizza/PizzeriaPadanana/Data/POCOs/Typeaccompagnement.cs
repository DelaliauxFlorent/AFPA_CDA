using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    /// <summary>
    /// Classe correspondante à la table TypeAccompagnements
    /// </summary>
    public partial class Typeaccompagnement
    {
        /// <summary>
        /// Constructeur (pour la liste)
        /// </summary>
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

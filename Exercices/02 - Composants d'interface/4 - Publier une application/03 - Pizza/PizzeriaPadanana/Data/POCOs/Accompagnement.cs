using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    public partial class Accompagnement
    {
        public Accompagnement()
        {
            Itemsmenus = new HashSet<Itemsmenu>();
            Lignescommandes = new HashSet<Lignescommande>();
        }

        public int IdAccompagnement { get; set; }
        public string NomAccompagnement { get; set; }
        public decimal PrixAccompagnement { get; set; }
        public decimal? MesureAccompagnement { get; set; }
        public string ImageAccompagnement { get; set; }
        public int IdTypeAccompagnement { get; set; }
        public bool? Actif { get; set; }

        public virtual Typeaccompagnement IdTypeAccompagnementNavigation { get; set; }
        public virtual ICollection<Itemsmenu> Itemsmenus { get; set; }
        public virtual ICollection<Lignescommande> Lignescommandes { get; set; }
    }
}

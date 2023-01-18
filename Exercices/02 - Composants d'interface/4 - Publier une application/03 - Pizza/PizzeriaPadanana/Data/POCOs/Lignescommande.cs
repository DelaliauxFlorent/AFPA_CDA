using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    public partial class Lignescommande
    {
        public int IdLignesCommandes { get; set; }
        public int? IdAccompagnement { get; set; }
        public int? IdMenu { get; set; }
        public int? IdCommande { get; set; }
        public int? IdPizza { get; set; }

        public virtual Accompagnement IdAccompagnementNavigation { get; set; }
        public virtual Commande IdCommandeNavigation { get; set; }
        public virtual Menu IdMenuNavigation { get; set; }
        public virtual Pizza IdPizzaNavigation { get; set; }
    }
}

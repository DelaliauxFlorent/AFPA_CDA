using System;
using System.Collections.Generic;

#nullable disable

namespace PizzeriaPadanana.Data.POCOs
{
    /// <summary>
    /// Classe correspondante à la table ItemsMenus
    /// </summary>
    public partial class Itemsmenu
    {
        public int IdItemsMenus { get; set; }
        public int? IdTypePizza { get; set; }
        public int? IdAccompagnement { get; set; }
        public int? IdMenu { get; set; }
        public int QteItem { get; set; }

        public virtual Accompagnement IdAccompagnementNavigation { get; set; }
        public virtual Menu IdMenuNavigation { get; set; }
        public virtual Typepizza IdTypePizzaNavigation { get; set; }
    }
}

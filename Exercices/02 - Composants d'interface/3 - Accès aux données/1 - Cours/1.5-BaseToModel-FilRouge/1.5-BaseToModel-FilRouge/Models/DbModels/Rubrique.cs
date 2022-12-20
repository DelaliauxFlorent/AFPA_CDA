using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Rubrique
    {
        public Rubrique()
        {
            InverseIdRubriqueParenteNavigation = new HashSet<Rubrique>();
            Produits = new HashSet<Produit>();
        }

        public int IdRubrique { get; set; }
        public string LibelleRubrique { get; set; }
        public int? IdRubriqueParente { get; set; }

        public virtual Rubrique IdRubriqueParenteNavigation { get; set; }
        public virtual ICollection<Rubrique> InverseIdRubriqueParenteNavigation { get; set; }
        public virtual ICollection<Produit> Produits { get; set; }
    }
}

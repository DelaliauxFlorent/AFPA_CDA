using System;
using System.Collections.Generic;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class Produit
    {
        public Produit()
        {
            Applicationstvas = new HashSet<Applicationstva>();
            Approvisions = new HashSet<Approvision>();
            Lignescommandes = new HashSet<Lignescommande>();
        }

        public int IdProduit { get; set; }
        public string LibelleProduit { get; set; }
        public string DescProduit { get; set; }
        public string RefProduit { get; set; }
        public decimal PrixHorsTaxe { get; set; }
        public string Photo { get; set; }
        public int Stock { get; set; }
        public int IdRubrique { get; set; }

        public virtual Rubrique IdRubriqueNavigation { get; set; }
        public virtual ICollection<Applicationstva> Applicationstvas { get; set; }
        public virtual ICollection<Approvision> Approvisions { get; set; }
        public virtual ICollection<Lignescommande> Lignescommandes { get; set; }
    }
}

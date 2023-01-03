using System;
using System.Collections.Generic;

#nullable disable

namespace _3_VisualisationRelationsAPI.Models
{
    public partial class Content
    {
        public int IdProduct { get; set; }
        public int IdCommand { get; set; }
        public int QuantityContent { get; set; }

        public virtual Command IdCommandNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}

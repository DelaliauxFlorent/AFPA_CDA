using System;
using System.Collections.Generic;

#nullable disable

namespace _3_VisualisationRelations.Models
{
    public partial class Content
    {
        public int IdContent { get; set; }
        public int IdProduct { get; set; }
        public int IdCommand { get; set; }
        public int QuantityContent { get; set; }

        public virtual Command Command { get; set; }
        public virtual Product Product { get; set; }
    }
}

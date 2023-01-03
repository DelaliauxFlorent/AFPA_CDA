using System;
using System.Collections.Generic;

#nullable disable

namespace _3_VisualisationRelationsAPI.Models
{
    public partial class Command
    {
        public Command()
        {
            Contents = new HashSet<Content>();
        }

        public int IdCommand { get; set; }
        public string DeliveryAddressCommand { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
    }
}

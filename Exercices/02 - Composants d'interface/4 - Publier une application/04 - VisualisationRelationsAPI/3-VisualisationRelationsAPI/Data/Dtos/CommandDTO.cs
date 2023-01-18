using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelationsAPI.Data.Dtos
{
    public class CommandDTO
    {
        public CommandDTO()
        {
            Contents = new HashSet<ContentDTOForCommands>();
        }

        public int IdCommand { get; set; }
        public string DeliveryAddressCommand { get; set; }

        public virtual ICollection<ContentDTOForCommands> Contents { get; set; }
    }

    public class CommandDTOBase
    {
        public int IdCommand { get; set; }
        public string DeliveryAddressCommand { get; set; }

    }
}

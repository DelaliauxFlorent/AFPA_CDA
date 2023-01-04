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
            Contents = new HashSet<ContentDTO>();
        }

        public int IdCommand { get; set; }
        public string DeliveryAddressCommand { get; set; }

        public virtual ICollection<ContentDTO> Contents { get; set; }
    }
}

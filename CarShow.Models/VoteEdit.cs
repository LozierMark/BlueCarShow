using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShow.Models
{
    public class VoteEdit
    {
        public int VoteId { get; set; }
        public int CarId { get; set; }
        public Guid OwnerId { get; set; }
        public int Paint { get; set; }
        public int Engine { get; set; }
        public int Interior { get; set; }
        public int BestOfShow { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShow.Models
{
    public class VoteEdit
    {
        public int CarId { get; set; }
        public Guid OwnerId { get; set; }
        public string Paint { get; set; }
        public string Engine { get; set; }
        public string Interior { get; set; }
        public string BestOfShow { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
    
}

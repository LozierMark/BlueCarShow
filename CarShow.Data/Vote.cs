using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShow.Data
{
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Paint { get; set; }
        [Required]
        public string Engine { get; set; }
        [Required]
        public string Interior { get; set; }
        [Required]
        public string BestOfShow { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

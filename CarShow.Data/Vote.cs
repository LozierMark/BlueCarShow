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
        public int CarId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public int Paint { get; set; }
        [Required]
        public int Engine { get; set; }
        [Required]
        public int Interior { get; set; }
        [Required]
        public int BestOfShow { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShow.Models
{
    public class VoteListItems
    {
        public int VoteId { get; set; }
        public Guid OwnerId { get; set; }
        public string Paint { get; set; }
        public string Engine { get; set; }
        public string Interior { get; set; }
        public string BestOfShow { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => $"{Paint} {Engine} {Interior} {BestOfShow}";
    }
}

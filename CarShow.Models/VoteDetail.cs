using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShow.Models
{
    public class VoteDetail
    {
       
        public int CarId { get; set; }
        public Guid OwnerId { get; set; }
        public string Paint { get; set; }
        public string Engine { get; set; }
        public string Interior { get; set; }
        public string BestOfShow { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{CarId}] {OwnerId} {Paint} {Engine} {Interior} {BestOfShow}";
    }
}

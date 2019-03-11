using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShow.Models
{
    public class VoteCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Paint { get; set; }

        [MaxLength(8000)]
        public string Engine { get; set; }
        public string Interior { get; set; }
        public string BestOfShow { get; set; }

        public override string ToString() => $"{Paint} {Engine} {Interior} {BestOfShow}";

    }
}

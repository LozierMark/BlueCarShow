using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShow.Models
{
    public class CarCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Make { get; set; }

        [MaxLength(8000)]
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public override string ToString() => $"{Make} {Model} {Year}";
       
        }
    }


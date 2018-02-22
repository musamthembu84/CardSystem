using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LostCard.Models
{
    public class mvcCards
    {
        public int ID { get; set; }

       // [Required(ErrorMessage ="Only 9 Digit Integer Value Accepted")]
       [Required]
       [MinLength(9)]
       [MaxLength(9)]
       [RegularExpression("^[0-9]*$", ErrorMessage ="Only 9 Digit Numbers Accepted")]
        public string SNumber { get; set; }


        public Nullable<System.DateTime> DateTime { get; set; }

        [Required]
        public string Campus { get; set; }
        public string SMS { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LostCard.Models
{
    public class mvcCards
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Only 9 Digit Integer Value Accepted")]
        public string SNumber { get; set; }


        public Nullable<System.DateTime> DateTime { get; set; }
        public string Campus { get; set; }
        public string SMS { get; set; }
    }
}
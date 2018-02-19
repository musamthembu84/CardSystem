using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LostCard.Models
{
    public class mvcCards
    {
        public int ID { get; set; }
        public string SNumber { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public string Campus { get; set; }
        public string SMS { get; set; }
    }
}
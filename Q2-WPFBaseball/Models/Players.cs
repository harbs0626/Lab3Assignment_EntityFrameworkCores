using System;
using System.Collections.Generic;

namespace Q2_WPFBaseball.Models
{
    public partial class Players
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BattingAverage { get; set; }
    }
}

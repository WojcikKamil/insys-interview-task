using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Data.Model
{
    public class FilteringProperties
    {
        public string ByText { get; set; } = "";
        public int YearMin { get; set; } = 0;
        public int YearMax { get; set; } = 9999;
        public long RatingMin { get; set; } = 0;
        public long RatingMax { get; set; } = 10;
    }
}

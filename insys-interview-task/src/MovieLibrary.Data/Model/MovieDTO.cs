using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLibrary.Data.Model
{
    public class MovieDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public decimal ImdbRating { get; set; }

        public ICollection<Category> Categories { get; set; }
    }

}

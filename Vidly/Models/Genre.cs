using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Genre")]
        public string Name { get; set; }

        public List<Movie> Movies{ get; set; }
    }
}
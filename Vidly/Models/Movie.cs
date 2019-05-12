using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do filme")]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Media type")]
        public MediaType MediaType { get; set; }

        [Display(Name = "Media type")]
        public byte MediaTypeId { get; set; }

        [Display(Name = "Release date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Release { get; set; }

        [Display(Name = "Date added")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Added { get; set; }

        [Display(Name = "Stock items", ShortName = "Stock")]
        [Range(1,5)]
        public byte Stock { get; set; }

    }
}
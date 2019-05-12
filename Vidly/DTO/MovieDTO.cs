using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do filme")]
        public string Name { get; set; }

        public byte GenreId { get; set; }


        public byte MediaTypeId { get; set; }

        public DateTime Release { get; set; }

        public DateTime Added { get; set; }

        [Range(1, 5)]
        public byte Stock { get; set; }
    }
}
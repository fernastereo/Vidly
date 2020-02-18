using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int id { get; set; }
        [Required]
        [StringLength(150)]
        public string name { get; set; }
        [Required]
        public int genreId { get; set; }
        [Required]
        public DateTime releaseDate { get; set; }
        [Required]
        public DateTime dateAdded { get; set; }
        [Required]
        [Range(1, 20)]
        public int stock { get; set; }

    }
}
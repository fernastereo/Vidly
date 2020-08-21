using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models {
    public class Movie {
        /// <summary>
        /// Represents the internal unique identification for any movie
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Represents the name of a movie
        /// </summary>
        [Required]
        [StringLength(150)]
        public string name { get; set; }
        
        /// <summary>
        /// Represents the genre of a movie
        /// </summary>
        public Genre genre { get; set; }

        /// <summary>
        /// Represents the foreign key to Genre model
        /// </summary>
        [Required]
        public int genreId { get; set; }

        /// <summary>
        /// Represents the release date of a movie
        /// </summary>
        [Required]
        public DateTime releaseDate { get; set; }

        /// <summary>
        /// Represents the date a movie was added to stock
        /// </summary>
        [Required]
        public DateTime dateAdded { get; set; }

        /// <summary>
        /// Represents the number of copies of any movie in stock
        /// </summary>
        [Required]
        [Range(1, 20)]
        public int stock { get; set; }
    }
}
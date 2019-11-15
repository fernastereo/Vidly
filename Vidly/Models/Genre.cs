using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        public int id { get; set; }

        /// <summary>
        /// Represents the name of a genre
        /// </summary>
        [Required]
        public string name { get; set; }
    }
}
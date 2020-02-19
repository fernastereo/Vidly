using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }
        public bool isSubscribedToNewsLetter { get; set; }
        public byte membershipTypeId { get; set; }
        public MembershipTypeDto membershipType { get; set; }
        //[Min18YearsIfAMember]
        public DateTime? birthDate { get; set; }
    }
}
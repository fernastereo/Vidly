using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    /// <summary>
    /// Represents the type of membership choosen by a customer,
    /// each membership type confers a discount to the customer.
    /// </summary>
    public class MembershipType
    {
        /// <summary>
        /// Represents the internal unique identification for any customer
        /// </summary>
        public byte id { get; set; }
        /// <summary>
        /// Represents the name of the membership type
        /// </summary>
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        /// <summary>
        /// Represents the cost a customer must pay for his membership
        /// </summary>
        public short singUpFee { get; set; }
        /// <summary>
        /// Represents the duration in months of the membership
        /// </summary>
        public byte durationInMonths { get; set; }
        /// <summary>
        /// Represents the discount granted to a customer for the membership type choosen
        /// </summary>
        public byte discountRate { get; set; }

    }
}
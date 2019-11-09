using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models {
    /// <summary>
    /// Represnts a customer who can rent a movie
    /// </summary>
    public class Customer {
        /// <summary>
        /// Represents the internal unique identification for any customer
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Represents the fullname of a customer
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Represents if the customers allow us to send him news letter of our product
        /// </summary>
        public bool isSubscribedToNewsLetter { get; set; }
        /// <summary>
        /// Represents the type of membership choosen by the customer
        /// </summary>
        public MembershipType membershipType { get; set; }
        /// <summary>
        /// Represents the foreign key to membershiptype model
        /// </summary>
        public byte membershipTypeId { get; set; }


    }
}
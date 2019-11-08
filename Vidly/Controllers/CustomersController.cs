using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> customers = new List<Customer> {
                new Customer() { id = 1, name = "Tony Stark" },
                new Customer() { id = 2, name = "Steve Rogers" },
                new Customer() { id = 3, name = "Natasha Romanov" },
                new Customer() { id = 4, name = "Wanda Maximoff" },
                new Customer() { id = 5, name = "Nick Fury" },
                };

        // GET: Customers
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = from element in customers
                           where element.id == id
                           select element;

            return View(customer.SingleOrDefault());
        }
    }
}
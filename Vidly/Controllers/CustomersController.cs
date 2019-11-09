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
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private IEnumerable<Customer> getCustomers() {
            return new List<Customer> {
                new Customer() { id = 1, name = "Tony Stark" },
                new Customer() { id = 2, name = "Steve Rogers" },
                new Customer() { id = 3, name = "Natasha Romanov" },
                new Customer() { id = 4, name = "Wanda Maximoff" },
                new Customer() { id = 5, name = "Nick Fury" },
            };
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //var customer = from element in customers
            //               where element.id == id
            //               select element;

            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            //if (!customer.Any())
            //{
            //    return HttpNotFound();
            //}

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}
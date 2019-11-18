using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        public ActionResult New()
        {
            var membershipStypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipStypes
            };

            return View("customerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (customer.id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.id == customer.id);
                customerInDb.name = customer.name;
                customerInDb.birthDate = customer.birthDate;
                customerInDb.membershipTypeId = customer.membershipTypeId;
                customerInDb.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("customerForm", viewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.membershipType).ToList();
            //include is for eager loading. When you try to retrieve data and a relationship whiit another model
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //var customer = from element in customers
            //               where element.id == id
            //               select element;

            var customer = _context.Customers.Include(c => c.membershipType).SingleOrDefault(c => c.id == id);

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
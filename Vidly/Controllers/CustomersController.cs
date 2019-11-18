﻿using System;
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
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipStypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("index", "Customers");
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
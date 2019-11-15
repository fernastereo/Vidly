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
    /// <summary>
    /// 
    /// </summary>
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Random()
        {
            var movie = new Movie() { name = "Matrix" };
            var customers = new List<Customer> {
                new Customer { name = "Customer 1" },
                new Customer { name = "Customer 2" },
                new Customer { name = "Customer 3" },
                new Customer { name = "Customer 4" },
                new Customer { name = "Customer 5" },
                new Customer { name = "Customer 6" },
            };

            var viewModel = new RandomMovieViewModel() {
                movie = movie,
                customers = customers
            };

            return View(viewModel);
            //return Content("Hello Kitty");
            //return HttpNotFound();
            //return new EmptyResult();


            //return RedirectToAction("index", "home", new { page = 1, sortBy = "name"});
        }

        public ActionResult Edit(int id) {

            return Content("Id: " + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy) {
            //? sirve para indicar que el parametro es opcional

            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            //var movies = new List<Movie>{
            //    new Movie { id = 1, name = "Matrix" },
            //    new Movie { id = 2, name = "Endgame" },
            //};

            //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            var movies = _context.Movies.Include(c => c.genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.genre).SingleOrDefault(c => c.id == id);
            return View(movie);
        }

        //Creating a custom route: method 2: (Attrubute routing)
        //First you need to enable it on RouteCinfig.cs: 
        //add: routes.MapMvcAttributeRoutes();
        //Then you can add your route as follows:
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month) {
            return Content("Year: " + year + " Month: " + month);
        }

        
    }
}
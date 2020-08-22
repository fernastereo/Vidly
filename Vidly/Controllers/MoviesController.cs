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

        public ActionResult New() {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };
            
            return View("movieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("movieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("movieForm", viewModel);
            }

            if (movie.id == 0)
            {
                movie.dateAdded = DateTime.Now.Date;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.id == movie.id);
                movieInDb.name = movie.name;
                movieInDb.releaseDate = movie.releaseDate;
                movieInDb.stock = movie.stock;
                movieInDb.genreId = movie.genreId;
            }

            _context.SaveChanges();

            return RedirectToAction("index", "Movies");
        }

        public ActionResult Index() {
            //? [int? pageIndex] sirve para indicar que el parametro es opcional
            //var movies = _context.Movies.Include(c => c.genre).ToList();
            return View();
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
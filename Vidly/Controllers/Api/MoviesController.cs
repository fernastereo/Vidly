using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/Movies
        public IHttpActionResult Get()
        {
            var movieDto = _context.Movies
                .Include(c => c.genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDto);
        }

        // GET: api/Movies/5
        public IHttpActionResult Get(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST: api/Movies
        [HttpPost]
        public IHttpActionResult createMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.id = movie.id;
            return Created(new Uri(Request.RequestUri + "/" + movie.id), movieDto);
        }

        // PUT: api/Movies/5
        [HttpPut]
        public IHttpActionResult updateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok(movieDto);
        }

        [HttpDelete]
        public IHttpActionResult deleteCustomers(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

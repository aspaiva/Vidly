using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.DTO;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private Vidly.Models.VidlyDBContext _context;
        public MoviesController()
        {
            _context = new Models.VidlyDBContext();
        }

        [HttpGet]
        public IEnumerable<MovieDTO> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
        }

        public MovieDTO GetMovie(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Movie movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Movie, MovieDTO>(movie);
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO) {
            if (!ModelState.IsValid)
                return BadRequest();

            if (movieDTO == null)
                return BadRequest();

            Movie movie = Mapper.Map<MovieDTO, Movie>(movieDTO);

            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Created(location: new Uri(Request.RequestUri + "/" + movie.Id), content: movieDTO);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovies (int Id)
        {
            if (!ModelState.IsValid || Id == 0)
                return BadRequest();

            Movie movie = _context.Movies.FirstOrDefault(m => m.Id == Id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id, MovieDTO movieDTO) {
            if (!ModelState.IsValid)
                return BadRequest();

            if (movieDTO == null)
                return BadRequest();

            Movie movie = _context.Movies.FirstOrDefault(m => m.Id == Id);

            if (movie == null)
                return NotFound();

            Mapper.Map(movieDTO, movie);
            _context.SaveChanges();

            return Ok();
        }
    }
}

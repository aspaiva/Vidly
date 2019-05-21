using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Vidly.Controllers.Api
{
    public class GenresController : ApiController
    {
        private Vidly.Models.VidlyDBContext _db;

        public GenresController()
        {
            _db = new Models.VidlyDBContext();
        }

        // GET api/<controller>
        public IEnumerable<Models.Genre> Get()
        {
            return _db.Genres.ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var genre = _db.Genres.SingleOrDefault(g => g.Id == id);

            if (genre != null)
            {
                _db.Genres.Remove(genre);
                _db.SaveChanges();
            }
        }
    }
}
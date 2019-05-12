using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using Vidly.Models;
using Vidly.DTO;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private VidlyDBContext _context;

        public CustomersController()
        {
            _context = new VidlyDBContext();
        }

        [HttpGet]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        [HttpGet]
        public CustomerDTO GetCustomer(int Id)
        {
            Customer cust = _context.Customers.FirstOrDefault(c => c.Id == Id);

            if (cust == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDTO>(cust);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO custDTO)
        {
            if (ModelState.IsValid)
            {
                Customer cust = Mapper.Map<CustomerDTO, Customer>(custDTO);

                _context.Customers.Add(cust);
                _context.SaveChanges();

                return Created(new Uri(Request.RequestUri + "/" + cust.Id.ToString()), custDTO);
            }
            else
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            if (Id == 0)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Customer cust = _context.Customers.FirstOrDefault(c => c.Id == Id);

            if (cust == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(cust);
            _context.SaveChanges();

            //return new HttpResponseMessage(HttpStatusCode.OK);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int Id, CustomerDTO custDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Customer custInDB = _context.Customers.FirstOrDefault(c => c.Id == Id);

            if (custInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(custDTO, custInDB);  //map custdto into custindb

            _context.SaveChanges();

            return Ok();
        }
    }
}

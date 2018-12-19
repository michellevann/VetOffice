using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VetOffice.Models;
using VetOffice.Services;

namespace VetOffice.WebAPI.Controllers
{
    [Authorize]
    public class CustomerController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            CustomerService customerService = CreateCustomerService();
            var customers = customerService.GetCustomers();
            return Ok(customers);
        }

        public IHttpActionResult Get(int id)
        {
            CustomerService customerService = CreateCustomerService();
            var customer = customerService.GetCustomerById(id);
            return Ok(customer);
        }

        public IHttpActionResult Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCustomerService();
            if (!service.CreateCustomer(customer))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(CustomerEdit customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCustomerService();
            if (!service.UpdateCustomer(customer))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCustomerService();
            if (!service.DeleteCustomer(id))
                return InternalServerError();
            return Ok();
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var customerService = new CustomerService(userId);
            return customerService;
        }
    }
}

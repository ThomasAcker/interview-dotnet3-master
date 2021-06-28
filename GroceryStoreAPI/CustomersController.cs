using System.Collections.Generic;
using GroceryStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private ICustomerService CustomerService { get; set; }

        public CustomersController(ICustomerService customerService)
        {
            this.CustomerService = customerService;
        }

        // GET: api/<controller>
        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return CustomerService.GetCustomers();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Customer GetCustomerById(int id)
        {
            return CustomerService.GetCustomerById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
            CustomerService.AddCustomer(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            CustomerService.UpdateCustomer(id, value);
        }
    }
}

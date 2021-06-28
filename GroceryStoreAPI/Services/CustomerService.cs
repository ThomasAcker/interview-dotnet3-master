using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CustomerService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public List<Customer> GetCustomers()
        {
            return GetData().customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return GetData().customers.FirstOrDefault(x => x.id == id);
        }
      
        public void AddCustomer(string name)
        {
            var data = GetData();
            var nextid = data.customers.OrderByDescending(x => x.id).ToList().First().id + 1;
            data.customers.Add(new Customer { id = nextid, name = name });
            SaveData(data);
        }

        public void UpdateCustomer(int id, string newName)
        {
            var updateCustomer = GetData().customers.FirstOrDefault(x => x.id == id);
            updateCustomer.name = newName;
        }

        private Root GetData()
        {
            return JsonConvert.DeserializeObject<Root>(System.IO.File.ReadAllText(_hostingEnvironment.ContentRootPath + "/database.json"));
        }

        private void SaveData(Root data)
        {
            System.IO.File.WriteAllText(_hostingEnvironment.ContentRootPath + "/database.json", JsonConvert.SerializeObject(data));
        }
    }
}


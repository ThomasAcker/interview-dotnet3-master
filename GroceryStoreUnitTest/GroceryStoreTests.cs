using GroceryStoreAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System.Linq;
using Xunit;


namespace GroceryStoreUnitTest
{
    public class GroceryStoreTests
    {
        [Fact]
        public void TestGetCustomers()
        {
            var mockEnvironment = new Mock<IWebHostEnvironment>();
            mockEnvironment
           .Setup(m => m.ContentRootPath)
           .Returns(@"E:\RSM\interview-dotnet3-master\GroceryStoreAPI");

            var customerService = new CustomerService(mockEnvironment.Object);
            var customers = customerService.GetCustomers();
            Assert.True(customers.Count > 0);
        }

       
        [Fact]
        public void TestGetCustomerById()
        {
            var mockEnvironment = new Mock<IWebHostEnvironment>();
            mockEnvironment
           .Setup(m => m.ContentRootPath)
           .Returns(@"E:\RSM\interview-dotnet3-master\GroceryStoreAPI");

            var customerService = new CustomerService(mockEnvironment.Object);
            var id = 1;
            var customer = customerService.GetCustomerById(id);

            Assert.True(customer != null && customer.id == id);
        }

        [Fact]
        public void TestAddCustomer()
        {
            var mockEnvironment = new Mock<IWebHostEnvironment>();
            mockEnvironment
           .Setup(m => m.ContentRootPath)
           .Returns(@"E:\RSM\interview-dotnet3-master\GroceryStoreAPI");

            var customerService = new CustomerService(mockEnvironment.Object);
            string name = "Thomas";
            customerService.AddCustomer(name);
            
            var customers = customerService.GetCustomers();

            Assert.True(customers.FirstOrDefault(x => x.name == "Thomas") != null);
        }
       
        [Fact]
        public void TestUpdateCustomer()
        {
            var mockEnvironment = new Mock<IWebHostEnvironment>();
            mockEnvironment
           .Setup(m => m.ContentRootPath)
           .Returns(@"E:\RSM\interview-dotnet3-master\GroceryStoreAPI");

            var customerService = new CustomerService(mockEnvironment.Object);
            int id = 3;
            string newName = "Jack";
            customerService.UpdateCustomer(id, newName);

            var customer = customerService.GetCustomerById(id);

            Assert.True(customer.id == id && customer.name == newName);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion


namespace WestWindSystem.BLL
{
    public class CustomerServices
    {
        //Create a field for the property to hold our context
        //readonly since we should not be able to update the context outside the WestWindContext Class

        private readonly WestWindContext _context;

        public CustomerServices(WestWindContext context)
        {
            _context = context;
        }

        //Method to return all the customers
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(string id)
        {
            id = id.ToLower();

            Customer? customer = _context.Customers.Where(C => C.CustomerId.ToLower() == id).FirstOrDefault();
//FirstOrDefault because if not record is found you can't return the first() of nothing. If that happens return the default for an object which is null
            return customer;
        }



    }
}

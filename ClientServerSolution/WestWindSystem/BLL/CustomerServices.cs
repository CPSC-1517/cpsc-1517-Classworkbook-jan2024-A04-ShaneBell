using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using WestWindSystem.Entities;
using WestWindSystem.DAL;
#endregion

namespace WestWindSystem.BLL
{
    public class CustomerServices
    {
        //Create a field for the context 
        private readonly WestWindContext _context;

        //When we instantiate this class we need the context to be provided so we know where the DB is. A service cannot do anything unless it knows where the data is.

        public CustomerServices(WestWindContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerByCustomerID(string customerID) 
        {
        Customer aCustomer = _context.Customers.Where(C =>C.CustomerId == customerID).FirstOrDefault();
            //FirstOrDefault beacause if it does not return anything it will give a null exception if it returns null (no records found). 
        return aCustomer;
        }

        



    }
}

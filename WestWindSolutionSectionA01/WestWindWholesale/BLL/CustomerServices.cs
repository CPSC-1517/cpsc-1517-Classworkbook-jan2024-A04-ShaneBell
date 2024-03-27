using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindWholesale.DAL;
using WestWindWholesale.Models;

namespace WestWindWholesale.BLL
{
    public class CustomerServices
    {
        //holds the context
        private readonly WestWindContext _context;

        //give the context the data it needs to connect
        public CustomerServices(WestWindContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

    }
}

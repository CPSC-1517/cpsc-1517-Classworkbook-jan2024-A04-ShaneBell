using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public  class OrderServices

    {

        private readonly WestWindContext _context;

        public OrderServices(WestWindContext context)
        {
            _context = context;
        }

        public List<Order> LookupOrdersByCustomerID(string customerID)
        {
            return _context.Orders.Where(O => O.CustomerId == customerID).ToList();
        }
    }
}

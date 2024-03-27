using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindWholesale.DAL;
using WestWindWholesale.Models;

namespace WestWindWholesale.BLL
{
    public class OrderServices
    {
        //holds the context
        private readonly WestWindContext _context;

        //give the context the data it needs to connect
        public OrderServices(WestWindContext context)
        {
            _context = context;
        }

        public List<Order> LookUpOrdersByCustomerID(string customerID)
        {
            return _context.Orders.Where(O => O.CustomerId == customerID).ToList();
        }

    }
}

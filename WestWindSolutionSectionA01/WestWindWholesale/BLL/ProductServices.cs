using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindWholesale.DAL;
using WestWindWholesale.Models;

namespace WestWindWholesale.BLL
{
    public class ProductServices
    {
        //holds the context
        private readonly WestWindContext _context;

        //give the context the data it needs to connect
        public ProductServices(WestWindContext context)
        {
            _context = context;
        }

        //Method to list all the products
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

    }
}

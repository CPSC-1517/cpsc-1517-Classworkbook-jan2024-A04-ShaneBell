using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        private readonly WestWindContext _context;

        public ProductServices(WestWindContext context)
        {
            _context = context;
        }
        public List<Product> GetProductsByCategoryID(int categoryID)
        {
            return _context.Products
           .Include(P=>P.Supplier)
           .Where(P => P.CategoryId == categoryID).ToList();
        }

        public Product? LookProductByID(int productID)
        {
            return _context.Products.Where(P => P.ProductId == productID).FirstOrDefault();
        }
    }
}

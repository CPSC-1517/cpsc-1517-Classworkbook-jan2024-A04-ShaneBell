using Microsoft.EntityFrameworkCore;
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
    public class ProductServices
    {
        private readonly WestWindContext _context;

        public ProductServices(WestWindContext context)
        {
            _context = context;
        }

        public List<Product> GetProductsByCategoryID(int categoryID)
        {
            return _context.Products.
                Where(p => p.CategoryId == categoryID)
                .Include(p => p.Supplier)
               .ToList();
        }

        public List<Product> GetProductsByPartialName(string partialName)
        {
            partialName = partialName.ToLower();

            return _context.Products.
                Where(p => p.ProductName.ToLower().Contains(partialName))
                .Include(p => p.Supplier)
               .ToList();
        }
        public Product? GetProductById(int productID) 
        {        
            return _context.Products.Where(p=>p.ProductId==productID).FirstOrDefault();
        }

        public void UpdateProduct(Product product) //Accept the product object that contains the updated product
        { 
            if(product == null) 
            {
                throw new ArgumentNullException("Product argument cannot be null");            
            }
            _context.Products.Update(product);
            _context.SaveChanges();       
        }

        public void AddProduct(Product product) //Accept the product object that contains the updated product
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product argument cannot be null");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void DeleteProduct(Product product) //Accept the product object that contains the updated product
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product argument cannot be null");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void DiscontinueProduct(Product product) //Accept the product object that contains the updated product
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product argument cannot be null");
            }
            product.Discontinued = true;
            UpdateProduct(product);
        }
    }
}

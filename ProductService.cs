using _22._10.Context;
using _22._10.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._10
{
    public class ProductService
    {
        private readonly ShopContext _context;

        public ProductService()
        {
            _context = new ShopContext();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product updatedProduct)
        {
            try
            {
                _context.Products.Update(updatedProduct);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Conflict detected. Reloading the latest data.");
                var databaseEntry = _context.Entry(updatedProduct).GetDatabaseValues();
                if (databaseEntry == null)
                {
                    Console.WriteLine("Product has been deleted.");
                }
                else
                {
                    var dbProduct = databaseEntry.ToObject() as Product;
                    Console.WriteLine($"Latest Data: {dbProduct?.Name}, {dbProduct?.Price}");
                    // Обработка конфликта: например, обновление UI или ручное разрешение
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public Product GetProduct(int productId)
        {
            return _context.Products.Find(productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}

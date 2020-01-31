using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComApp.API.Helpers;
using eComApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace eComApp.API.Data
{
    public class EComRepository : IEComRepository
    {
        private readonly DataContext _context;
        public EComRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<bool> DeleteProduct(int productId)
        {
            Product product = await _context.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
            product.IsActive = false;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<PagedList<Product>> GetProducts(ProductParams productParams)
        {
            var products =  _context.Products.Where(p => p.IsActive == true).AsQueryable();
            if (!string.IsNullOrEmpty(productParams.Category))
            {
                products = products.Where(p => p.Category == productParams.Category);
            }
            if (!string.IsNullOrEmpty(productParams.Search))
            {
                products = products.Where(p => p.Name.Contains(productParams.Search));
            }
            
            products = products.OrderByDescending(p => p.Name);

            return await PagedList<Product>.CreateAsync(products); 
        }

        public async Task<Product> SaveProduct(Product product)
        {
            product.CreatedDate = DateTime.Now;
            product.UpdatedDate = DateTime.Now;
            product.UpdatedBy = product.CreatedBy;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            Product list = await _context.Products.Where(p => p.Id == product.Id).FirstOrDefaultAsync();
            list.Name = product.Name;
            list.Category = product.Category;
            list.UnitPrice = product.UnitPrice;
            list.Description = product.Description;
            list.ImageUrl = product.ImageUrl;
            list.UpdatedBy = product.CreatedBy;
            list.UpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
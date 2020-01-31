using System.Collections.Generic;
using System.Threading.Tasks;
using eComApp.API.Helpers;
using eComApp.API.Models;

namespace eComApp.API.Data
{
    public interface IEComRepository
    {
         Task<Product> SaveProduct(Product product);

         Task<bool> UpdateProduct(Product product);

         Task<PagedList<Product>> GetProducts(ProductParams productParams);
         Task<bool> DeleteProduct(int productId);
    }
}
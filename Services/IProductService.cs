using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapProject.Domain;

namespace AutoMapProject.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int productId);
        Task<bool> CreateProductAsync(Product product);
    }
}

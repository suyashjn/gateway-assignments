using System.Collections.Generic;
using PMS.Common.Models;

namespace PMS.Data.RepositoryInterface
{
    public interface IProductRepository
    {
        string DeleteProduct(int id);
        string UpdateProduct(Product model);
        string AddProduct(Product model);
        List<Product> GetProducts(int userId);
    }
}

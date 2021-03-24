using System.Collections.Generic;
using PMS.Common.Models;

namespace PMS.Business.ManagerInterface
{
    public interface IProductManager
    {
        string DeleteProduct(int id);
        string UpdateProduct(Product model);
        string AddProduct(Product model);
        List<Product> GetProducts(int userId);
    }
}

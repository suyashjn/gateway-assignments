using System.Collections.Generic;
using PMS.Business.ManagerInterface;
using PMS.Common.Models;
using PMS.Data.RepositoryInterface;

namespace PMS.Business.ManagerClass
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public string AddProduct(Product model)
        {
           return _productRepository.AddProduct(model);
        }

        public string DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

        public List<Product> GetProducts(int userId)
        {
            return _productRepository.GetProducts(userId);
        }

        public string UpdateProduct(Product model)
        {
            return _productRepository.UpdateProduct(model);
        }
    }
}

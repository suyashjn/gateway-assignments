using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PMS.Common.Models;
using PMS.Data.RepositoryInterface;


namespace PMS.Data.RepositoryClass
{
    public class ProductRepository : IProductRepository
    {
        private readonly PMSContext _dbContext;

        public ProductRepository(PMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// This method gets all products in list which was entered by user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Product> GetProducts(int userId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Data.Models.Product, Product>());
            var mapper = config.CreateMapper();

            List<Product> productList = new List<Product>();

            var data = _dbContext.Products.Where(p => p.UserId == userId).ToList();

            foreach (var item in data)
            {
                Product product = mapper.Map<Product>(item);
                productList.Add(product);
            }
            return productList;
        }

        public string AddProduct(Product model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, Data.Models.Product>());
            var mapper = config.CreateMapper();

            var product = mapper.Map<Data.Models.Product>(model);

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return "Product Added Successfully.";
        }

        public string UpdateProduct(Product model)
        {
            var entity = _dbContext.Products.Find(model.ProductId);
            if(entity != null)
            {
                entity.Name = model.Name;
                entity.Category = model.Category;
                entity.Price = model.Price;
                entity.Quantity = model.Quantity;
                entity.ShortDescription = model.ShortDescription;
                entity.LongDescription = model.LongDescription;
                entity.SmallImage = model.SmallImage;
                entity.LongImage = model.LongImage;

                _dbContext.SaveChanges();
                return "Product Updated Successfully!";
            }
            else
            {
                return "Something went wrong. Please try after sometime.";
            }
        }

        public string DeleteProduct(int id)
        {
            if (id <= 0)
                return "Not a valid Product.";
            else
            {
                var product = _dbContext.Products.Find(id);
                
                if(product == null)
                {
                    return "Something went wrong or Product not Found...Contact Admin....";
                }
                else
                {
                    _dbContext.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                    _dbContext.SaveChanges();

                    return "Deleted Successfully.";
                }
            }
        }
    }
}

using System.Collections.Generic;
using System.Web.Http;
using PMS.Business.ManagerInterface;
using PMS.Common.Models;


namespace PMS.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductManager _productManager;
        
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;   
        }

        public string DeletProduct(int id)
        {
            return _productManager.DeleteProduct(id);
        }

        [HttpPut, Route("UpdateProduct")]
        public string UpdateProduct([FromBody]Product model)
        {
            return _productManager.UpdateProduct(model);
        }

        [HttpPost, Route("AddProduct")]
        public string AddProduct([FromBody]Product model)
        {
            return _productManager.AddProduct(model);
        }

        [HttpGet, Route("GetAllProducts/{userId}")]
        public List<Product> GetProducts(int userId)
        {
            return _productManager.GetProducts(userId);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using e_commerce_Api.Interfaces;
using e_commerce_Api.Repositories;

namespace e_commerce_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       private readonly IProduct _proRepoContext;
        
        public ProductsController()
        {
            _proRepoContext = new ProductRepository(new ModelContext());
            
        } 

        [HttpGet]
        public   ActionResult<IEnumerable<Products>> GetAllProducts()
        {
            IEnumerable<Products> products = _proRepoContext.GetAll();
            return Ok(products);
        }
       
       
       

    }
}

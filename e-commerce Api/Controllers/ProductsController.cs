using Microsoft.AspNetCore.Mvc;
namespace e_commerce_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProduct _proRepoContext;
        public ProductsController(IProduct productContext)
        {
            _proRepoContext = productContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetAllProducts()
        {
            IEnumerable<Products> products = _proRepoContext.GetAll().Result;
            if (products.Count() > 0)
            {
                return Ok(products);
            }
            else
            {
                return NoContent();
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task< ActionResult<Products>> GetProductById(int id)
        {
            if (id<=0)
            {
                return BadRequest();
            }
            else
            {
                var products = await _proRepoContext.GetById(id);
                if (products == null)
                {
                    return NotFound("product not Exist");
                }
                return Ok(products);
            }

        }

        [HttpGet("categoriesproducts")]
        public ActionResult<IEnumerable<Products>> GetAllProductsOfCategory(int category_Id)
        {
            if (category_Id<=0)
            {
                return BadRequest("invalid category id");
            }
            else
            {
                IEnumerable<Products> productsList=_proRepoContext.GetAllProductsCategory(category_Id).Result;
                if (productsList.Any())
                {
                    return Ok(productsList);
                }
                return NoContent();
            }

        }

        [HttpPost]
        public ActionResult AddNewProduct(Products products)
        {
           
            var addedProd= _proRepoContext.Add(products).Result;
            return CreatedAtAction(nameof(GetAllProducts), addedProd); ;

        }
        [HttpPut]
        public  ActionResult<Products> UpdateProduct(int id,Products products)
        {
            if (id!=products.ProductID)
            {
                return BadRequest();
            }
            else
            {
                var  product =  _proRepoContext.Update(products).Result;
                if (product != null)
                    return Ok(product);
                else return NotFound("This item not exist");
            }
        }

        [HttpDelete]
        public  ActionResult DeleteProduct(int id)
        {
            if (id > 0)
            {
                var prod= _proRepoContext.GetById(id).Result;
                if (prod!=null)
                {
                    bool resp = _proRepoContext.Delete(id);
                    if (resp)
                    {
                        return Ok("deleted");
                    }
                    else
                    {
                        return NotFound("problem in delete from db");
                    }
                }
                else
                {
                    return NotFound("this product dosen't exist");
                }
             
            }
            else
            {
                return BadRequest("send an id");
            }
        }





    }
}

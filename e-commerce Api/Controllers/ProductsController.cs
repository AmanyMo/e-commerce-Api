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
        public ProductsController()
        {

        }
    }
}

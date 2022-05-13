using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using e_commerce_Api.Data;
using e_commerce_Api.Models;

namespace e_commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategories _catContext;

        public CategoriesController(ICategories context)
        {
            _catContext = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetAllCategories()
        {
           IEnumerable<Categories> categories=await  _catContext.GetAll();
            if (categories.Count()>0)
            {
                return Ok(categories);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> GetCategoryById(int id)
        {
            if (id > 0)
            {
                var category = await _catContext.GetById(id);
                if (category == null)
                {
                    return NotFound("category not exist");
                }
                else
                    return Ok(category);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutCategories(int id, Categories categories)
        {
            if (id != categories.CategoryID)
            {
                return BadRequest();
            }
            else
            {
                Categories category1 = _catContext.Update(categories).Result;
                if (category1 == null)
                {
                    return NotFound("can't modify this obj cuz not exist");
                }
                return Ok(category1);
            }
        }
       

        [HttpPost]
        public  ActionResult<Categories> PostNewCategory(Categories category)
        {
           Categories category1= _catContext.Add(category).Result;
            if (category1==null)
            {
                return NotFound("no category added");
            }
            else
                return CreatedAtAction(nameof(GetAllCategories), category1);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteCategories(int id)
        {
            if (id > 0)
            {
                Categories cat=_catContext.GetById(id).Result;
                if (cat!=null)
                {
                    bool resp = _catContext.Delete(id);
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
                    return NotFound("Category dosen't exist");
                }
               
            }
            else
            {
                return BadRequest("send an id");
            }
        }

        //private  bool CategoriesExists(int id)
        //{
        //    return _catContext.GetById(id).Result;
        //}
    }
}

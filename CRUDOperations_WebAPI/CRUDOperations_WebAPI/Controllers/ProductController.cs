using CRUDOperations_WebAPI.Data;
using CRUDOperations_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRUDOperations_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ContextClass _context;
        public ProductController(ContextClass context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var products = _context.Products.ToList();
                if (products.Count == 0)
                {
                    return NotFound("Products records is not found");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound("Product record is not found");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult post(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult put(Product model)
        {
            try
            {
                if (model == null || model.Id == 0)
                {
                    if (model == null)
                    {
                        return BadRequest("Products record is invalid");
                    }
                    else if (model.Id == 0)
                    {
                        return BadRequest("Products record is invalid");
                    }
                }
                var product = _context.Products.Find(model.Id);
                if (product == null)
                {
                    return NotFound("Products record is not found");
                }
                product.ProductType = model.ProductType;
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                _context.SaveChanges();
                return Ok("Products record is update");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return BadRequest("Products record is Invalid");
                }
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok("Products record is deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}

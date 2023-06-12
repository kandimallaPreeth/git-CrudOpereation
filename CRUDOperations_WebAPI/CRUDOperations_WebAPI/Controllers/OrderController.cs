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
    public class OrderController : ControllerBase
    {
        private readonly ContextClass _context;
        public OrderController(ContextClass context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var order = _context.Orders.ToList();
                if (order.Count == 0)
                {
                    return NotFound("Orders record is notfound");
                }
                return Ok(order);
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
                var order = _context.Orders.Find(id);
                if (order == null)
                {
                    return NotFound("Order records is not found");
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public IActionResult post(Order order)
        {
            try
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return Ok("Orders record is Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult put(Order model)
        {
            try
            {
                if (model == null || model.Id == 0)
                {
                    if (model == null)
                    {
                        return BadRequest("Orders record is invalid");
                    }
                    else if (model.Id == 0)
                    {
                        return BadRequest("Orders record is invalid");
                    }
                }
                var order = _context.Orders.Find(model.Id);
                if (order == null)
                {
                    return NotFound("Orders record is not found");
                }
                order.OrderedDateTime = model.OrderedDateTime;
                order.Amount = model.Amount;
                order.product = model.product;
                order.customer = model.customer;
                _context.SaveChanges();
                return Ok("Orders record is updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            try
            {
                var order = _context.Orders.Find(id);
                if (order == null)
                {
                    return NotFound("Orders record is not found");
                }
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return Ok("Orders record is deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}

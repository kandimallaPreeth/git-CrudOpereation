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
    public class CustomerController : ControllerBase
    {
        private readonly ContextClass _context;
        public CustomerController(ContextClass context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                var customer = _context.Customers.ToList();
                if (customer.Count == 0)
                {
                    return NotFound("Customers recodes not found");
                }
                
                return Ok(customer);
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
                var customer = _context.Customers.Find(id);
                if (customer == null)
                {
                    return NotFound("Customer record is not found");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Customer model)
        {
            try
            {
                _context.Customers.Add(model);
                _context.SaveChanges();
                return Ok("Customer record is created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Customer model)
        {
            try
            {
                if (model == null || model.Id == 0)
                {
                    if (model == null)
                    {
                        return BadRequest("invalid value");
                    }
                    else if (model.Id == 0)
                    {
                        return BadRequest("invalid in value");
                    }
                }
                var customer = _context.Customers.Find(model.Id);
                if (customer == null)
                {
                    return NotFound("Customer record is not found");
                }
                customer.Name = model.Name;
                customer.Email = model.Email;
                customer.Address = model.Address;
                customer.PhoneNumber = model.PhoneNumber;
                customer.DateOfAssociation = model.DateOfAssociation;
                _context.SaveChanges();
                return Ok("Customer record is Updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                if (customer == null)
                {
                    return NotFound("Customer record is not found");
                }
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return Ok("Customer record is deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

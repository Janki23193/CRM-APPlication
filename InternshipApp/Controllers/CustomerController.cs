using InternshipApp.Models;
using InternshipApp.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customer;
        public CustomerController(ICustomerRepository customer)
        {
            _customer = customer;       
        }
        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody]Customer customer)
        {
            try
            {
                var data = await _customer.CreateAsync(customer);
                if(data== true)
                {
                    return Ok("Cutomer has been saved successfully");
                }
                return NotFound("Error found while saving customer");
            }catch(Exception)
            {
                return BadRequest("Internal server error");
            }
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customer = await _customer.GetAllAsync();
                if (customer != null)
                {
                    return Ok(customer);
                }

                return NotFound();

            }
            catch (Exception)
            {
                return BadRequest("internal server error");
            }

        }
        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            try
            {
                var customer = await _customer.GetAsync(id);
                if (customer != null)
                {
                    return Ok(customer);
                }
                return NotFound("Id hasn't been found");
            }
            catch (Exception)
            {
                return BadRequest("internal server error");
            }
        }
        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            try
            {
                var data = await _customer.UpdateAsync(id, customer);
                if (data == true)
                {
                    return Ok("Updated Sucessfully");
                }
                return NotFound("Record has not been found");

            }
            catch (Exception)
            {
                return BadRequest("Internal server error");
            }
        }
        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            try
            {
                var data = await _customer.DeleteAsync(id);
                if (data == true)
                {
                    return Ok("Item deleted successfully");
                }
                return NotFound("The record hasn't been found");
            }
            catch (Exception)
            {
                return BadRequest("Internal server error");
            }
        }
    }
}

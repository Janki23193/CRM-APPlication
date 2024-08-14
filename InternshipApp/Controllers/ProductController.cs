using Microsoft.AspNetCore.Mvc;
using InternshipApp.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshipApp.Repos.Interfaces;
using InternshipApp.Models;

namespace InternshipApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _product;
        public ProductController(IProductRepository product)
        {
            _product = product;
            
        }
        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var data = await _product.GetAllAsync();
                if(data!=null)
                {
                    return Ok(data);
                }
                    return NotFound();             
            }
            catch (Exception)
            {
                return BadRequest("internal server error");
            }
        }
        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProduct([FromRoute]int id)
        {
            try {
                var data = await _product.GetAsync(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest("internal server error");
            }           
        }
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var data = await _product.DeleteAsync(id);
                if (data == true)
                {
                    return Ok("Sucessfully deleted");
                }
                return NotFound("Id has not been found");
            }
            catch (Exception)
            {
                return BadRequest("internal server error");
            }
        }
        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody]Product product)
        {
            try
            {
                var data = await _product.UpdateAsync(id, product);
                if(data== true)
                {
                    return Ok("Updated successfully");
                }
                return NotFound("Something went wrong");
            }
            catch(Exception)
            {
                return BadRequest("internal server error");
            }
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody]Product product)
        {
            try
            {
                var data = await _product.CreateAsync(product);
                if(data == true)
                {
                    return Ok("Product successfully Saved");
                }
                return NotFound("Something went wrong");
            }
            catch(Exception)
            {
                return BadRequest("internal server error");
            }
        }

    }
}

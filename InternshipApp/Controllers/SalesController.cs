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
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _SalesRepository;
        public SalesController(ISalesRepository salesRepository)
        {
            _SalesRepository = salesRepository;
        }
        [HttpPost("CreateSales")]
        public async Task<IActionResult> CreateSales([FromBody]Sales sales)
        {
            try
            {
                var data = await _SalesRepository.CreateSalesAsync(sales);
                if (data == true)
                {
                    return Ok(data);
                }
                return NotFound("Something went wrong");
            }
            catch (Exception)
            {
                return BadRequest("internal server error");
            }
         
        }
        [HttpDelete("DeleteSales/{id}")]
        public async Task<IActionResult> DeleteSales([FromRoute]int id)
        {
            try
            {
                var data = await _SalesRepository.DeleteSalesAsync(id);
                if (data == true)
                {
                    return Ok("Sales successfully deleted");
                }

                return NotFound("Id hasn't been found");
            }
            catch (Exception)
            {
                return BadRequest("Internal server error");
            }
        }
        [HttpGet("GetAllSales")]
        public async Task<IActionResult> GetAllSales()
        {
            try
            {
                var data = await _SalesRepository.GetAllSalesAsync();
                if(data != null)
                {
                    return Ok(data);
                }
                return NotFound("No Records have been found");
            }catch(Exception)
            {
                return BadRequest("Internal server error");
            }
        }
        [HttpGet("GetSalesById/{id}")]
        public async Task<IActionResult> GetSalesById([FromRoute]int id)
        {
            try
            {
                var data = await _SalesRepository.GetSalesAsync(id);
                if (data != null)
                {
                    return Ok(data);
                }
                return NotFound("Id hasn't been found");
            }
            catch (Exception)
            {
                return BadRequest("Internal server error");
            }
        }
        [HttpPut("UpdateSales/{id}")]
        public async Task<IActionResult> UpdateSales([FromRoute]int id, [FromBody]Sales sale)
        {
            try
            {
                var data = await _SalesRepository.UpdateSalesAsync(id, sale);
                if (data == true)
                {
                    return Ok("Record has been successfully updated");
                }
                return NotFound("Id that you're looking for hasn't been found, sorry");

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }
    }
}

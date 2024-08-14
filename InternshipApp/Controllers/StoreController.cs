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
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        public StoreController(IStoreRepository StoreRepository)
        {
            _storeRepository = StoreRepository;
        }
        [HttpGet("GetAllStore")]
        public async Task<IActionResult> GetAllStore()
        {
            try
            {
                var data = await _storeRepository.GetAllStoreAsync();
                if (data != null)
                {
                    return Ok(data);
                }
                return NotFound("data has not been found");
            }
            catch (Exception)
            {
                return BadRequest("internal server error");
            }
           
        }
        [HttpGet("GetStoreById/{id}")]
        public async Task<IActionResult> GetStore([FromRoute]int id)
        {
            try
            {
                var data = await _storeRepository.GetAsync(id);
                if (data != null)
                {
                    return Ok(data);
                }
                return NotFound("Id has not been found");
            }
            catch (Exception)
            {
                return BadRequest("server error");
            }
        }
        [HttpPost("CreateStore")]
        public async Task<IActionResult> CreateStore([FromBody]Store store)
        {
            try
            {
                var data = await _storeRepository.CreateStoreAsync(store);
                if (data == true)
                {
                    return Ok(store);
                }
                return null;
            }
            catch (Exception)
            {
                return BadRequest("Internal server error");
            }
           
        }
        [HttpPut("updateStore/{id}")]
        public async Task<IActionResult> UpdateStore([FromRoute]int id, Store store)
        {
            try
            {
                var data = await _storeRepository.UpdateStoreAsync(id, store);
                if (data == true)
                {
                    return Ok("Updated successfully");
                }
                return NotFound("Id hasn't been found");
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
            
        }
        [HttpDelete("DeleteStore/{id}")]
        public async Task<IActionResult> DeleteStore([FromRoute]int id)
        {
            try
            {
                var data = await _storeRepository.DeleteStoreAsync(id);
                if (data == true)
                {
                    return Ok("Deleted successfully");
                }
                return NotFound("Id has not been found");
            }
            catch (Exception)
            {
                return BadRequest("something went wrong");
            }
        }

    }
}

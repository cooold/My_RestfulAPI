using firstAPI_2023_04_19.Dtos;
using firstAPI_2023_04_19.IService;
using firstAPI_2023_04_19.Models;
using firstAPI_2023_04_19.Parameters;
using firstAPI_2023_04_19.Service;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstAPI_2023_04_19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IQueryStaff _StaffService;

        public StaffController(IQueryStaff staffService)
        {
            _StaffService = staffService;
        }

        //GET api https://localhost:7249/api/Staff
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] StaffSelectParameters value)
        {
            var result = await _StaffService.QueryStaff(value);
            if (result == null || result.Count() <= 0)
            {
                return NotFound("cannot find");
            }
            return Ok(result);
        }

        //GET api https://localhost:7249/api/Staff/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await _StaffService.QueryStaffByid(id);
            if (result == null)
            {
                return NotFound("cannot find Id:" + id);
            }
            return Ok(result);
        }

        //GET api https://localhost:7249/api/Staff/all/Infomessages
        [HttpGet("all/Infomessages")]
        public async Task<IActionResult> GetAllInfo([FromQuery] StaffSelectParameters value)
        {
            var result = await _StaffService.QueryStaffMessages(value);
            if (result == null || result.Count() <= 0)
            {
                return NotFound("cannot find");
            }
            return Ok(result);
        }

        //GET api https://localhost:7249/api/Staff/2/Infomessages
        [HttpGet("{id}/Infomessages")]
        public async Task<IActionResult> GetOneInfo(int id)
        {
            var result = await _StaffService.QueryStaffMessagesByid(id);
            if (result == null)
            {
                return NotFound("cannot find Id:" + id);
            }
            return Ok(result);
        }


        //POST api https://localhost:7249/api/Staff
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StaffPostDto value)
        {
            Staff insert =  await _StaffService.InsertStaff(value);
            return CreatedAtAction(nameof(GetOne), new { id = insert.Id }, insert);
        }
        // PUT api https://localhost:7249/api/Staff/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] StaffPutDto value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            bool update = await _StaffService.PutStaff(id, value);
            if (update == false)
            {
                return NotFound();
            }
            return NoContent();
        }
        // Patch api https://localhost:7249/api/Staff/1
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument value)
        {
            bool update = await _StaffService.PatchStaff(id, value);
            if (update == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE https://localhost:7249/api/Staff/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool delete = await _StaffService.DeleteStaff(id);
            if (delete == false)
            {
                return NotFound("找不到刪除的資源");
            }
            return NoContent();
        }

        // DELETE https://localhost:7249/api/Staff/list/22,23
        [HttpDelete("list/{ids}")]
        public async Task<IActionResult> Deletes(string ids)
        {
            List<int>? delets = ids.Split(',')?.Select(Int32.Parse)?.ToList();
            bool delete = await _StaffService.DeleteStaffs(delets);
            if (delete == false)
            {
                return NotFound("找不到刪除的資源");
            }
            return NoContent();
        }
    }
}

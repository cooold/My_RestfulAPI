using firstAPI_2023_04_19.Dtos;
using firstAPI_2023_04_19.IService;
using firstAPI_2023_04_19.Models;
using firstAPI_2023_04_19.Parameters;
using firstAPI_2023_04_19.Service;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstAPI_2023_04_19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoMessagesController : ControllerBase
    {
        private readonly IQueryInfoMessages _InfoMessagesService;

        public InfoMessagesController(IQueryInfoMessages InfoMessagesService)
        {
            _InfoMessagesService = InfoMessagesService;
        }
        //GET api https://localhost:7249/api/InfoMessages
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InfoMessageSelectParameters value)
        {
            var result = await _InfoMessagesService.QueryInfoMessages(value);
            if (result == null || result.Count() <= 0)
            {
                return  NotFound("找不到資源");
            }
            return  Ok(result);
        }

        //GET api https://localhost:7249/api/InfoMessages/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await _InfoMessagesService.QueryInfoMessagesByid(id);
            if (result == null)
            {
                return NotFound("找不到 Id:" + id);
            }
            return Ok(result);
        }

        //POST api https://localhost:7249/api/InfoMessages
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] infoMessagePostDto value)
        {
            
            InfoMessage insert = await _InfoMessagesService.InsertInfoMessage(value);
            return CreatedAtAction(nameof(GetOne),new { id = insert.Id}, insert);
        }

        //PUT api https://localhost:7249/api/InfoMessages/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] infoMessagePutDto value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            bool update = await _InfoMessagesService.PutInfoMessage(id, value);
            if(update == false)
            {
                return NotFound("找不到更新的資源");
            }
            return NoContent();
        }

        // Patch https://localhost:7249/api/InfoMessages/1
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument value)
        {
            bool patch = await _InfoMessagesService.PatchInfoMessage(id, value);
            if (patch == false)
            {
                return NotFound("找不到更新的資源");
            }
            return NoContent();
        }

        // DELETE https://localhost:7249/api/InfoMessages/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool delete = await _InfoMessagesService.DeleteInfoMessage(id);
            if (delete == false)
            {
                return NotFound("找不到刪除的資源");
            }
            return NoContent();
        }

        // DELETE https://localhost:7249/api/InfoMessages/list/22,23
        [HttpDelete("list/{ids}")]
        public async Task<IActionResult> Deletes(string ids)
        {
            List<int>? delets = ids.Split(',')?.Select(Int32.Parse)?.ToList();
            bool delete = await _InfoMessagesService.DeleteInfoMessages(delets);
            if (delete == false)
            {
                return NotFound("找不到刪除的資源");
            }
            return NoContent();
        }
    }
}

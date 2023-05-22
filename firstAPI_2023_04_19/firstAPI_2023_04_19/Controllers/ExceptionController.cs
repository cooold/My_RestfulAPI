using firstAPI_2023_04_19.Filter;
using Microsoft.AspNetCore.Mvc;

namespace firstAPI_2023_04_19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(SampleExceptionFilter))]

    public class ExceptionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index(int x , int y)
        {
            return Ok(x / y);
        }
    }
}

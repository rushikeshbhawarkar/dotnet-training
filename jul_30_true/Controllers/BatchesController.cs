using jul_30_true.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _30_Jul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBatches()
        {
            var batches = new List<Batch> {
                new Batch{ Id=1101, BatchName="C Sharp" },
                new Batch{ Id=1102, BatchName="Asp dot net" }
            };
            return Ok(batches);
        }
    }
}
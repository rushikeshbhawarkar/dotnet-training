using aug_03.Model;
using aug_03.Repository;
using Microsoft.AspNetCore.Mvc;

namespace aug_03.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService _batchService;

        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;
        }

        [HttpGet]
        public IActionResult GetAllBatches()
        {
            return Ok(_batchService.GetAllBatches());
        }

        [HttpGet("{id}")]
        public IActionResult GetBatchById(int id)
        {
            var batch = _batchService.GetBatchById(id);

            if (batch == null)
                return NotFound("Batch not found");

            return Ok(batch);
        }

        [HttpPost]
        public IActionResult AddBatch(Batch batch)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _batchService.AddBatch(batch);
            return Ok(batch);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBatch(int id, Batch batch)
        {
            if (id != batch.BatchId)
            {
                return BadRequest("Id mismatch");
            }

            _batchService.UpdateBatch(batch);
            return Ok("Batch Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBatch(int id)
        {
            _batchService.DeleteBatch(id);
            return Ok("Batch Deleted");
        }
    }
}
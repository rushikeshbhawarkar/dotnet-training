using assignment_aug_08.Model;
using assignment_aug_08.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_aug_08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchRepository _batchRepository;

        public BatchController(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var batches = _batchRepository.GetAll();
            return Ok(batches);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var batch = _batchRepository.GetById(id);
            if (batch == null) return NotFound();
            return Ok(batch);
        }

        [HttpPost]
        public IActionResult Create(Batch batch)
        {
            var createdBatch = _batchRepository.Add(batch);
            return Ok(createdBatch);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Batch batch)
        {
            var updatedBatch = _batchRepository.Update(id, batch);
            if (updatedBatch == null) return NotFound();
            return Ok(updatedBatch);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _batchRepository.Delete(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}

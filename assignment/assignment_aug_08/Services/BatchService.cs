using assignment_aug_08.Data;
using assignment_aug_08.Model;

namespace assignment_aug_08.Services
{
    public class BatchService
    {
        private readonly AppDbContext _context;

        public BatchService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Batch> GetAll()
        {
            return _context.Batches.ToList();
        }

        public Batch? GetById(int id)
        {
            return _context.Batches.Find(id);
        }

        public Batch Add(Batch batch)
        {
            _context.Batches.Add(batch);
            _context.SaveChanges();
            return batch;
        }

        public Batch? Update(int id, Batch batch)
        {
            var existing = _context.Batches.Find(id);
            if (existing == null) return null;

            existing.BatchName = batch.BatchName;
            existing.StartDate = batch.StartDate;

            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var batch = _context.Batches.Find(id);
            if (batch == null) return false;

            _context.Batches.Remove(batch);
            _context.SaveChanges();
            return true;
        }
    }
}

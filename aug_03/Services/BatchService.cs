using aug_03.Model;
using aug_03.Repository;

namespace aug_03.Services
{
    public class BatchService : IBatchService
    {
        private static List<Batch> batches = new()
        {
            new Batch { BatchId = 1, BatchName = "DotNet-Batch-01", BatchDurationMonths = 6, BatchCredits = 30 },
            new Batch { BatchId = 2, BatchName = "Java-Batch-01", BatchDurationMonths = 6, BatchCredits = 30 },
            new Batch { BatchId = 3, BatchName = "DataScience-Batch-01", BatchDurationMonths = 12, BatchCredits = 60 },
            new Batch { BatchId = 4, BatchName = "React-Batch-01", BatchDurationMonths = 3, BatchCredits = 15 }
        };

        public List<Batch> GetAllBatches()
        {
            return batches;
        }

        public Batch GetBatchById(int id)
        {
            return batches.FirstOrDefault(b => b.BatchId == id);
        }

        public void AddBatch(Batch batch)
        {
            batches.Add(batch);
        }

        public void UpdateBatch(Batch batch)
        {
            var existingBatch = GetBatchById(batch.BatchId);
            if (existingBatch != null)
            {
                existingBatch.BatchName = batch.BatchName;
                existingBatch.BatchDurationMonths = batch.BatchDurationMonths;
                existingBatch.BatchCredits = batch.BatchCredits;
            }
            else
            {
                throw new Exception("Batch not found");
            }
        }

        public void DeleteBatch(int id)
        {
            var existingBatch = GetBatchById(id);

            if (existingBatch == null)
                throw new Exception("Batch not found");

            batches.Remove(existingBatch);
        }
    }
}
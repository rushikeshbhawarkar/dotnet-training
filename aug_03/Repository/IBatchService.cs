using aug_03.Model;

namespace aug_03.Repository
{
    public interface IBatchService
    {
        List<Batch> GetAllBatches();

        Batch GetBatchById(int id);

        void AddBatch(Batch batch);

        void UpdateBatch(Batch batch);

        void DeleteBatch(int id);
    }
}
using assignment_aug_08.Model;

namespace assignment_aug_08.Repository
{
    public interface IBatchRepository
    {
        IEnumerable<Batch> GetAll();
        Batch? GetById(int id);
        Batch Add(Batch batch);
        Batch? Update(int id, Batch batch);
        bool Delete(int id);
    }
}

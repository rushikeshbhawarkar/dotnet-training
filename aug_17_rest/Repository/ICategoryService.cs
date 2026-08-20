using aug_17_rest.Models;

namespace aug_17_rest.Repository
{
    public interface ICategoryService
    {
        List<Category> GetCategories();

        Category? GetCategoryById(int id);

        void AddCategory(Category category);
    }
}

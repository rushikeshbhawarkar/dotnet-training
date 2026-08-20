using aug_17_rest.Data;
using aug_17_rest.Models;
using aug_17_rest.Repository;

namespace aug_17_rest.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext context;

        public CategoryService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public Category? GetCategoryById(int id)
        {
            return context.Categories.Find(id);
        }
    }
}

using ShopEaseApp.Models;

namespace ShopEaseApp.Services
{
    public class CategoryService
    {
        private readonly List<Category> _categories = new();
        private int _nextId = 1;

        public CategoryService()
        {
            foreach (var name in new[] { "Electronics", "Books", "Fashion", "Sports", "Furniture", "Groceries" })
                AddCategory(name);
        }

        public Category AddCategory(string name)
        {
            var category = new Category(_nextId++, name);
            _categories.Add(category);
            return category;
        }

        public (bool Success, string Message) UpdateCategory(int categoryId, string newName)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category == null)
                return (false, $"Category with ID {categoryId} not found.");

            category.Name = newName;
            return (true, "Category updated successfully.");
        }

        public (bool Success, string Message) DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category == null)
                return (false, $"Category with ID {categoryId} not found.");

            _categories.Remove(category);
            return (true, "Category deleted successfully.");
        }

        public List<Category> GetAllCategories() => _categories.ToList();
    }
}

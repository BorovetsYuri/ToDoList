using ToDoList.Models;

namespace ToDoList.DatebaseAccess.Interfaces
{
    public interface ICategoryDataProvider
    {
        List<Category> GetAllCategories();
        Category AddCategory(Category category);
        Category UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}

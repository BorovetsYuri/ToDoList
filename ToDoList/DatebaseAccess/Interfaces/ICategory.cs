using ToDoList.Models;

namespace ToDoList.DatebaseAccess.Interfaces
{
    public interface ICategory
    {
        List<Category> GetAllCategories();
        Category AddCategory(Category category);
        Category UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}

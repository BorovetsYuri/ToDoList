using Microsoft.AspNetCore.Mvc;
using ToDoList.DatebaseAccess.Interfaces;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryDataProvider category;
        public CategoryController(ICategoryDataProvider category)
        {
            this.category = category;
        }
        public IActionResult GetAllCategories()
        {
            var categories = category.GetAllCategories();
            EditCategoriesPageModel editCategoriesPageModel = new EditCategoriesPageModel(categories);
            return View("Categories", editCategoriesPageModel);
        }
        public IActionResult AddCategory(Category category)
        {
            var newCategory = this.category.AddCategory(category);
            return RedirectToAction("GetAllCategories");
        }
        public IActionResult UpdateCategory(Category category)
        {
            var updatedCategory = this.category.UpdateCategory(category);
            return RedirectToAction("GetAllCategories");
        }
        public IActionResult DeleteCategory(int id)
        {
            category.DeleteCategory(id);
            return RedirectToAction("GetAllCategories");
        }
    }
}

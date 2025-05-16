using Microsoft.AspNetCore.Mvc;
using ToDoList.DatebaseAccess.Interfaces;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory category;
        public CategoryController(ICategory category)
        {
            this.category = category;
        }
        public IActionResult GetAllCategories()
        {
            var categories = category.GetAllCategories();
            return View(categories);
        }
        public IActionResult AddCategory(Category category)
        {
            var newCategory = this.category.AddCategory(category);
            return View(newCategory);
        }
        public IActionResult UpdateCategory(Category category)
        {
            var updatedCategory = this.category.UpdateCategory(category);
            return View(updatedCategory);
        }
        public IActionResult DeleteCategory(int id)
        {
            category.DeleteCategory(id);
            return RedirectToAction("GetAllCategories");
        }
    }
}

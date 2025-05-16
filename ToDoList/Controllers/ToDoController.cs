using Microsoft.AspNetCore.Mvc;
using ToDoList.DatebaseAccess.Interfaces;
using ToDoList.DatebaseAccess.Models;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoItemDataProvider toDoItemDataProvider;
        private readonly ICategoryDataProvider categoryDataProvider;
        public ToDoController(IToDoItemDataProvider toDoItemDataProvider, ICategoryDataProvider categoryDataProvider)
        {
            this.toDoItemDataProvider = toDoItemDataProvider;
            this.categoryDataProvider = categoryDataProvider;
        }
        public IActionResult Index()
        {
            List<ToDoItem> toDo = new List<ToDoItem>();
            List<Category> categories = categoryDataProvider.GetAllCategories();
            var toDoList = toDoItemDataProvider.GetAllToDoItems();
            foreach (var item in toDoList)
            {
                var category = categories.FirstOrDefault(c => c.Id == item.CategoryId);
                toDo.Add(new ToDoItem(item.Id, item.Title, item.Deadline, category, item.CompleteDate));
            }
            List<ToDoItem> unComplitedToDoItems = toDo.Where(y => y.CompleteDate == null).ToList();
            List<ToDoItem> completedToDoItems = toDo.Where(y => y.CompleteDate != null).OrderByDescending(x => x.CompleteDate).ToList();
            HomePageModel homePageModel = new HomePageModel(unComplitedToDoItems, completedToDoItems, categories);
            return View(homePageModel);
        }
        public IActionResult Create(HomePageModel model)
        {
            toDoItemDataProvider.AddToDoItem(model.ToDoInput);
            return RedirectToAction("Index");
        }
        public IActionResult GetToDoById(int id)
        {
            var toDoItemDBO = toDoItemDataProvider.GetToDoItemById(id);
            List<Category> categories = categoryDataProvider.GetAllCategories();          
            return View("Update", new EditToDoPageModel(toDoItemDBO, categories));
        }
        public IActionResult Update(EditToDoPageModel page)
        {
            toDoItemDataProvider.UpdateToDoItem(page.ToDoItem);
            return RedirectToAction("Index");
        }
        public IActionResult Complete(int id)
        {
            toDoItemDataProvider.CompleteToDoItem(id);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            toDoItemDataProvider.DeleteToDoItem(id);
            return RedirectToAction("Index");
        }
    }
}

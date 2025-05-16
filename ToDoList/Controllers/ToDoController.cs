using Microsoft.AspNetCore.Mvc;
using ToDoList.DatebaseAccess.Interfaces;
using ToDoList.DatebaseAccess.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoItemDataProvider toDoItemDataProvider;
        public ToDoController(IToDoItemDataProvider toDoItemDataProvider)
        {
            this.toDoItemDataProvider = toDoItemDataProvider;
        }
        public IActionResult GetAllToDo()
        {
            var toDoList = toDoItemDataProvider.GetAllToDoItems();
            return View(toDoList);
        }
        public IActionResult Add(ToDoItemCreateDBO toDo)
        {
            var toDoCreate = toDoItemDataProvider.AddToDoItem(toDo);
            return View(toDoCreate);
        }
        public IActionResult TakeToDoById(int id)
        {
            var toDoItem = toDoItemDataProvider.GetToDoItemById(id);
            return View(toDoItem);
        }
        public IActionResult UpdateToDoItem(ToDoItemDBO toDo)
        {
            var toDoItem = toDoItemDataProvider.UpdateToDoItem(toDo);
            return View(toDoItem);
        }
        public IActionResult CompleteToDoItem(int id)
        {
            var toDoItem = toDoItemDataProvider.CompleteToDoItem(id);
            return View(toDoItem);
        }
    }
}

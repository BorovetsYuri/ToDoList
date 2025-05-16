using ToDoList.DatebaseAccess.Models;

namespace ToDoList.Models
{
    public class EditToDoPageModel
    {
        public ToDoItemDBO ToDoItem { get; set; }
        public List<Category> Categories { get; set; }
        public EditToDoPageModel(ToDoItemDBO toDoItem, List<Category> categories)
        {
            ToDoItem = toDoItem;
            Categories = categories;
        }
        public EditToDoPageModel()
        {
            ToDoItem = new ToDoItemDBO();
            Categories = new List<Category>();
        }
    }
}

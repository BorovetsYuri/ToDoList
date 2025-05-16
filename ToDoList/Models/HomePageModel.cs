using ToDoList.DatebaseAccess.Models;

namespace ToDoList.Models
{
    public class HomePageModel
    {
        public ToDoItemCreateDBO ToDoInput { get; set; }
        public List<ToDoItem> UnComplitedToDoItems { get; set; }
        public List<ToDoItem> CompletedToDoItems { get; set; }
        public List<Category> Categories { get; set; }
        public HomePageModel(List<ToDoItem> unComplitedToDoItems, List<ToDoItem> completedToDoItems, List<Category> categories)
        {
            ToDoInput = new ToDoItemCreateDBO();
            UnComplitedToDoItems = unComplitedToDoItems;
            CompletedToDoItems = completedToDoItems;
            Categories = categories;
        }
        public HomePageModel()
        {
            
        }
    }
}

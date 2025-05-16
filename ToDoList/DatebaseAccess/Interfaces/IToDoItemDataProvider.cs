using ToDoList.DatebaseAccess.Models;

namespace ToDoList.DatebaseAccess.Interfaces
{
    public interface IToDoItemDataProvider
    {
        List<ToDoItemDBO> GetAllToDoItems();
        ToDoItemDBO GetToDoItemById(int id);
        ToDoItemDBO AddToDoItem(ToDoItemCreateDBO toDoItem);
        ToDoItemDBO UpdateToDoItem(ToDoItemDBO toDoItem);
        ToDoItemDBO CompleteToDoItem(int id);
        void DeleteToDoItem(int id);
    }
}

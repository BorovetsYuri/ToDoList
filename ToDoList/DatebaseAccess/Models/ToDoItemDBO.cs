using ToDoList.Models;

namespace ToDoList.DatebaseAccess.Models
{
    public class ToDoItemDBO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CompletionDate { get; set; }

        public int CategoryId { get; set; }

        public DateTime CompleteDate { get; set; }

        public ToDoItemDBO(int id, string title, DateTime completionDate, int categoryId, DateTime completeDate)
        {
            Id = id;
            Title = title;
            CompletionDate = completionDate;
            CategoryId = categoryId;
            CompleteDate = completeDate;
        }
    }
}

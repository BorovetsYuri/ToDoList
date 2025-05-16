
namespace ToDoList.DatebaseAccess.Models
{
    public class ToDoItemDBO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Deadline { get; set; }

        public int CategoryId { get; set; }

        public DateTime? CompleteDate { get; set; }

        public ToDoItemDBO(int id, string title, DateTime deadline, int categoryId, DateTime? completeDate)
        {
            Id = id;
            Title = title;
            Deadline = deadline;
            CategoryId = categoryId;
            CompleteDate = completeDate;
        }
        public ToDoItemDBO()
        {
            
        }
    }
}

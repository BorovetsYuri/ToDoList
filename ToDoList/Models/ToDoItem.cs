namespace ToDoList.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Deadline { get; set; }

        public Category Category { get; set; }

        public DateTime? CompleteDate { get; set; }

        public ToDoItem(int id, string title, DateTime deadline, Category category, DateTime? completeDate)
        {
            Id = id;
            Title = title;
            Deadline = deadline;
            Category = category;
            CompleteDate = completeDate;
        }
        public ToDoItem()
        {

        }
    }
}

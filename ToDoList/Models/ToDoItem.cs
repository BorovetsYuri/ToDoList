namespace ToDoList.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CompletionDate { get; set; }

        public Category Category { get; set; }

        public DateTime CompleteDate { get; set; }

        public ToDoItem(int id, string title, DateTime completionDate, Category category, DateTime completeDate)
        {
            Id = id;
            Title = title;
            CompletionDate = completionDate;
            Category = category;
            CompleteDate = completeDate;
        }
    }
}

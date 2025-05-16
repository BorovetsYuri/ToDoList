namespace ToDoList.DatebaseAccess.Models
{
    public class ToDoItemCreateDBO
    {
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public int CategoryId { get; set; }

        public ToDoItemCreateDBO(string title, DateTime deadline, int categoryId)
        {
            Title = title;
            Deadline = deadline;
            CategoryId = categoryId;
        }
        public ToDoItemCreateDBO()
        {
            Deadline = DateTime.Now;
        }
    }
}

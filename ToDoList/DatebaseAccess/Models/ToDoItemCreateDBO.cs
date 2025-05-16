namespace ToDoList.DatebaseAccess.Models
{
    public class ToDoItemCreateDBO
    {
        public string Title { get; set; }
        public DateTime CompletionDate { get; set; }
        public int CategoryId { get; set; }

        public ToDoItemCreateDBO(string title, DateTime completionDate, int categoryId)
        {
            Title = title;
            CompletionDate = completionDate;
            CategoryId = categoryId;
        }
    }
}

namespace ToDoList.Models
{
    public class EditCategoriesPageModel
    {
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public EditCategoriesPageModel(List<Category> categories)
        {
            Categories = categories;
        }
        public EditCategoriesPageModel()
        {
            Categories = new List<Category>();
        }
    }
}
namespace ToDoMVC.Models
{
    public class TaskToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public TaskToDo()
        {
            
        }
        public TaskToDo(int id, string title, string description, DateTime date)
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
        }

    }
}

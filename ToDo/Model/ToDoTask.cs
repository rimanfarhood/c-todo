namespace ToDo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get;  set; }
        public bool IsDone { get; set; }
        public DateTime? DueDate { get; set;}
        public Todo(int id, string title, DateTime? dueDate = null)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Title can not be empty");

            Id = id;
            Title = title;
            DueDate = dueDate;
            IsDone = false;
        }
        public bool UpdateTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                return false;

                Title = newTitle;
                return true;
        }

        public void MarkDone()
        {
            if (IsDone) return;
            IsDone = true;
        }
    }
}

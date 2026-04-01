namespace ToDo.Models
{
    public class Todo
    {
        public int Id { get; }
        public string Title { get; private set; }
        public bool IsDone { get; private set; }
        public DateTime? DueDate { get; private set;}
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
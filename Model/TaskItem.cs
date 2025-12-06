using System;

namespace TaskPro.Model
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public string Assignee { get; set; }

        public TaskItem(string title, string description, DateTime dueDate, Priority priority, string assignee)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = Status.ToDo;
            Assignee = assignee;
        }

        public TaskItem() { }

        public override string ToString()
        {
            return $"{Title} - {Status} (Due: {DueDate.ToShortDateString()}, Priority: {Priority})";
        }
    }
}

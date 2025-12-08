using System;
using System.Collections.Generic;
using System.Linq;
using TaskPro.Data;
using TaskPro.Model;
using TaskPro.Services.Searching;
using TaskPro.Services.Sorting;

namespace TaskPro.Services
{
    public class TaskManager
    {
        private readonly ITaskRepository _repository;
        private readonly Logger _logger;
        private List<TaskItem> _tasks;
        private readonly SearchService _searchService;

        public TaskManager(ITaskRepository repository)
        {
            _repository = repository;
            _logger = Logger.GetInstance();
            _tasks = _repository.Load();
            _searchService = new SearchService();
        }

        public void CreateTask(string title, string description, DateTime dueDate, Priority priority, string assignee)
        {
            var newTask = new TaskItem(title, description, dueDate, priority, assignee);
            _tasks.Add(newTask);
            _repository.Save(_tasks);
            _logger.Log($"Task Created: {newTask.Id} - {title}");
            Console.WriteLine("Task created successfully.");
        }

        public void UpdateTaskStatus(Guid id, Status newStatus)
        {
            var task = _searchService.LinearSearchById(_tasks, id);
            if (task != null)
            {
                var oldStatus = task.Status;
                task.Status = newStatus;
                _repository.Save(_tasks);
                _logger.Log($"Task Status Updated: {id} from {oldStatus} to {newStatus}");
                Console.WriteLine("Task status updated.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        public List<TaskItem> SearchTasks(string assignee)
        {
            return _searchService.SearchByAssignee(_tasks, assignee);
        }

        public void SortTasks(ISortStrategy strategy)
        {
            strategy.Sort(_tasks);
            Console.WriteLine("Tasks sorted.");
        }

        public List<TaskItem> GetOverdueTasks()
        {
            return _tasks.Where(t => t.DueDate < DateTime.Now && t.Status != Status.Done).ToList();
        }

        public List<TaskItem> GetUpcomingTasks(int days)
        {
            var threshold = DateTime.Now.AddDays(days);
            return _tasks.Where(t => t.DueDate >= DateTime.Now && t.DueDate <= threshold && t.Status != Status.Done).ToList();
        }

    }
}

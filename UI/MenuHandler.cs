using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPro.Data;
using TaskPro.Model;
using TaskPro.Services;
using TaskPro.Services.Sorting;

namespace TaskPro.UI
{
    public class MenuHandler
    {
        private readonly TaskManager _taskManager;

        public MenuHandler()
        {
            var repository = new JsonRepository();
            _taskManager = new TaskManager(repository);
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Task & Project Tracking System ---");
                Console.WriteLine("1. Create Task");
                Console.WriteLine("2. View All Tasks");
                Console.WriteLine("3. Update Task Status");
                Console.WriteLine("4. Search Tasks (by Assignee)");
                Console.WriteLine("5. Sort Tasks");
                Console.WriteLine("6. View Overdue Tasks");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();
                HandleInput(input);
            }
        }

        private void HandleInput(string input)
        {
            switch (input)
            {
                case "1":
                    CreateTask();
                    break;
                case "2":
                    ViewAllTasks();
                    break;
                case "3":
                    UpdateTaskStatus();
                    break;
                case "4":
                    SearchTasks();
                    break;
                case "5":
                    SortTasks();
                    break;
                case "6":
                    ViewOverdueTasks();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private void CreateTask()
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Description: ");
                string desc = Console.ReadLine();

                Console.Write("Enter Due Date (yyyy-mm-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
                {
                    Console.WriteLine("Invalid date format.");
                    return;
                }

                Console.Write("Enter Priority (0=Low, 1=Medium, 2=High): ");
                if (!Enum.TryParse(Console.ReadLine(), out Priority priority))
                {
                    Console.WriteLine("Invalid priority.");
                    return;
                }

                Console.Write("Enter Assignee: ");
                string assignee = Console.ReadLine();

                _taskManager.CreateTask(title, desc, dueDate, priority, assignee);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating task: {ex.Message}");
            }
        }

        private void ViewAllTasks()
        {
            var tasks = _taskManager.GetAllTasks();
            DisplayTasks(tasks);
        }

        private void UpdateTaskStatus()
        {
            Console.Write("Enter Task ID to update: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            Console.Write("Enter New Status (0=ToDo, 1=InProgress, 2=Done): ");
            if (!Enum.TryParse(Console.ReadLine(), out Status status))
            {
                Console.WriteLine("Invalid status.");
                return;
            }

            _taskManager.UpdateTaskStatus(id, status);
        }

        private void SearchTasks()
        {
            Console.Write("Enter Assignee Name: ");
            string assignee = Console.ReadLine();
            var results = _taskManager.SearchTasks(assignee);
            DisplayTasks(results);
        }

        private void SortTasks()
        {
            Console.WriteLine("Sort by: 1. Priority (High-Low)  2. Due Date (Soonest First)");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                _taskManager.SortTasks(new BubbleSortByPriority());
            }
            else if (choice == "2")
            {
                _taskManager.SortTasks(new BubbleSortByDate());
            }
            else
            {
                Console.WriteLine("Invalid sort option.");
            }
            ViewAllTasks();
        }

        private void ViewOverdueTasks()
        {
            var tasks = _taskManager.GetOverdueTasks();
            Console.WriteLine("--- Overdue Tasks ---");
            DisplayTasks(tasks);
        }

        private void DisplayTasks(List<TaskItem> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }

    }
}

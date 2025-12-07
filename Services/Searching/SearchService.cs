using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPro.Model;

namespace TaskPro.Services.Searching
{
    public class SearchService
    {
        // Linear Search by Assignee
        public List<TaskItem> SearchByAssignee(List<TaskItem> tasks, string assignee)
        {
            List<TaskItem> results = new List<TaskItem>();
            foreach (var task in tasks)
            {
                if (task.Assignee.Equals(assignee, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(task);
                }
            }
            return results;
        }

        // Linear Search by ID (for unsorted list)
        public TaskItem LinearSearchById(List<TaskItem> tasks, Guid id)
        {
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    return task;
                }
            }
            return null;
        }

        // Binary Search by ID (Requires sorted list by ID)
        public TaskItem BinarySearchById(List<TaskItem> tasks, Guid id)
        {
            // Sort by ID first for binary search to work
            var sortedTasks = tasks.OrderBy(t => t.Id).ToList();

            int left = 0;
            int right = sortedTasks.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = sortedTasks[mid].Id.CompareTo(id);

                if (comparison == 0)
                {
                    return sortedTasks[mid];
                }
                if (comparison < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return null;
        }
    }

}

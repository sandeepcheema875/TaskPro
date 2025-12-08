using System.Collections.Generic;
using TaskPro.Model;

namespace TaskPro.Services.Sorting
{
    public class BubbleSortByPriority : ISortStrategy
    {
        public void Sort(List<TaskItem> tasks)
        {
            int n = tasks.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // High priority (2) should come before Low (0)
                    // So if current is LESS than next, swap for descending order
                    if (tasks[j].Priority < tasks[j + 1].Priority)
                    {
                        TaskItem temp = tasks[j];
                        tasks[j] = tasks[j + 1];
                        tasks[j + 1] = temp;
                    }
                }
            }
        }
    }
}

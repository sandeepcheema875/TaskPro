using System.Collections.Generic;
using TaskPro.Model;

namespace TaskPro.Services.Sorting
{
    public class BubbleSortByDate : ISortStrategy
    {
        public void Sort(List<TaskItem> tasks)
        {
            int n = tasks.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Earlier date comes first
                    if (tasks[j].DueDate > tasks[j + 1].DueDate)
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

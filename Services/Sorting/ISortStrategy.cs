using System.Collections.Generic;
using TaskPro.Models;

namespace TaskPro.Services.Sorting
{
    public interface ISortStrategy
    {
        void Sort(List<TaskItem> tasks);
    }
}

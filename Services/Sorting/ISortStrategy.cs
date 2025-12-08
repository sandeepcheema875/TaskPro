using System.Collections.Generic;
using TaskPro.Model;

namespace TaskPro.Services.Sorting
{
    public interface ISortStrategy
    {
        void Sort(List<TaskItem> tasks);
    }
}

using System;
using System.Collections.Generic;
using TaskPro.Model;

namespace TaskPro.Data
{
    public interface ITaskRepository
    {
        List<TaskItem> Load();
        void Save(List<TaskItem> tasks);
    }

}
	

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TaskPro.Model;

namespace TaskPro.Data
{
    public class JsonRepository : ITaskRepository
    {
        private readonly string _filePath = "tasks.json";
        public List<TaskItem> Load()
        {
            if (!File.Exists(_filePath))
            {
                return new List<TaskItem>();
            }

            try
            {
                string json = File.ReadAllText(_filePath);
                if (string.IsNullOrWhiteSpace(json))
                    return new List<TaskItem>();

                return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tasks: {ex.Message}");
                return new List<TaskItem>();
            }
        }
        public void Save(List<TaskItem> tasks)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(tasks, options);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving tasks: {ex.Message}");
            }
        }


        public JsonRepository()
        {
        }
    }
}


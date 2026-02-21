using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace HospitalManagementSystem.Helpers
{
    public class JsonHelper
    {
        public static void SaveToFile<T>(string filePath, List<T> data)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, json);
        }

        public static List<T> LoadFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<T>();

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<T>>(json)
                   ?? new List<T>();
        }
    }
}

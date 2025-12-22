using System;
using System.IO;
using System.Text.Json;

namespace FileIOPractice
{
    class JsonProgram
    {
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Marks { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== JSON FILE I/O ===");

            // Get solution root
            string solutionRoot =
                Directory.GetParent(AppContext.BaseDirectory)
                         .Parent.Parent.Parent.FullName;

            // Project folder
            string projectFolder = Path.Combine(solutionRoot, "FileIOPractice");

            // JSON folder
            string jsonFolderPath = Path.Combine(projectFolder, "JsonFiles");
            Directory.CreateDirectory(jsonFolderPath);

            // JSON file path
            string jsonFilePath = Path.Combine(jsonFolderPath, "student.json");

            // Object to write
            Student student = new Student
            {
                Id = 1,
                Name = "Ram",
                Marks = 90
            };

            // Serialize (Object → JSON)
            string jsonData = JsonSerializer.Serialize(student);
            File.WriteAllText(jsonFilePath, jsonData);

            // Read JSON
            string jsonFromFile = File.ReadAllText(jsonFilePath);

            // Deserialize (JSON → Object)
            Student result =
                JsonSerializer.Deserialize<Student>(jsonFromFile);

            Console.WriteLine("\n--- JSON Content ---");
            Console.WriteLine($"{result.Id} {result.Name} {result.Marks}");
        }
    }
}

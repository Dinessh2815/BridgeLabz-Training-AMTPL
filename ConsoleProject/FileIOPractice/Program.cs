using System;
using System.IO;

namespace FileIOPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== TEXT FILE I/O ===");

            // 1️⃣ Get solution/project root (where .sln exists)
            string solutionRoot =
                Directory.GetParent(AppContext.BaseDirectory)
                         .Parent.Parent.Parent.FullName;

            // 2️⃣ Move into FileIOPractice project folder
            string projectFolder = Path.Combine(solutionRoot, "FileIOPractice");

            // 3️⃣ Build TextFiles folder path
            string textFolderPath = Path.Combine(projectFolder, "TextFiles");

            // 4️⃣ Ensure TextFiles directory exists
            Directory.CreateDirectory(textFolderPath);

            // 5️⃣ Build file path
            string filePath = Path.Combine(textFolderPath, "notes.txt");

            // 6️⃣ Write to file
            File.WriteAllText(filePath, "Hello File I/O\n");

            // 7️⃣ Append to file
            File.AppendAllText(filePath, "This is second line\n");
            File.AppendAllText(filePath, "Learning File I/O in C#\n");

            // 8️⃣ Read from file
            string content = File.ReadAllText(filePath);

            Console.WriteLine("\n--- File Content ---");
            Console.WriteLine(content);
        }
    }
}

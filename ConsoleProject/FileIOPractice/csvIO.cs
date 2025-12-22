using System;
using System.IO;

namespace FileIOPractice
{
    class CsvProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CSV FILE I/O ===");

            // Get solution root
            string solutionRoot =
                Directory.GetParent(AppContext.BaseDirectory)
                         .Parent.Parent.Parent.FullName;

            // Project folder
            string projectFolder = Path.Combine(solutionRoot, "FileIOPractice");

            // CSV folder
            string csvFolderPath = Path.Combine(projectFolder, "CsvFiles");
            Directory.CreateDirectory(csvFolderPath);

            // CSV file path
            string csvFilePath = Path.Combine(csvFolderPath, "students.csv");

            // Write CSV
            string[] csvData =
            {
                "Id,Name,Marks",
                "1,Ram,90",
                "2,Sam,85",
                "3,Ana,95"
            };

            File.WriteAllLines(csvFilePath, csvData);

            // Read CSV
            Console.WriteLine("\n--- CSV Content ---");
            string[] lines = File.ReadAllLines(csvFilePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                Console.WriteLine(string.Join(" | ", values));
            }
        }
    }
}

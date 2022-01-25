using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace Signature_Analysis_Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the directory (full path name): ");
            string DirectoryPath = CheckDirectory();  //Checking if Directory exists (method below)

            Console.WriteLine("Enter the CSV file location to view results (full path name): ");
            string csvFile = CheckCSVFileExist(); //Checking if CSVFile exists (method below)

            Processing_Directory pd = new Processing_Directory();
            pd.ProcessDirectory(DirectoryPath, csvFile);  //Process Directory (method in ProcessingDirectory.cs)
        }

        // Description: Checks if the path name exists

        public static string CheckDirectory()
        {

            string DirectoryPath = Console.ReadLine();
            while (Directory.Exists(DirectoryPath) == false)
            {
                Console.WriteLine("Directory not found. Please enter another directory (full path name): ");
                DirectoryPath = Console.ReadLine();
            }
            Console.WriteLine("Directory found.");
            return DirectoryPath;
        }

        /// Description: Checks if the csv file name exists
        public static string CheckCSVFileExist()
        {
            string csvFile = Console.ReadLine();
            while (File.Exists(csvFile) == false)
            {
                Console.WriteLine("CSV File not found. Please enter another CSV file (full path name): ");
                csvFile = Console.ReadLine();
            }
            Console.WriteLine("CSV File found.");
            return csvFile;
        }

    }
}
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Signature_Analysis_Assignment
{
    internal class Processing_Directory
    {
        public void ProcessDirectory(string directory, string csvFile)
        {
            foreach (string path in Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories))
            {
                if (File.Exists(path))  // If the object is a file == true
                    ProcessFile(path, csvFile);  //ProcessFile method below

                else if (Directory.Exists(path))  // If the object is a subdirectory == true
                    ProcessDirectory(path, csvFile); //Recursion back into ProcessDirectory method if subdirectory is found
            }
        }

        
        /// Description: Analyses each file found to get full path name, the file extension, the MD5 hash
        public void ProcessFile(string path, string csvFile)
        {
            Analyse_File af = new Analyse_File();
            string fileSignature = af.GetFileSignature(path);  //Getting the file signature (method in AnalyzeFile.cs)
            string fileType = af.GetFileType(fileSignature); // Getting the file type using the fileSignature (method in AnalyzeFile.cs)
            string hash = af.GetMD5Hash(path);  //Getting the MD5 hash of the file contents (method in AnalyzeFile.cs)
            af.CsvFill(path, fileType, hash, csvFile);  //CsvFill - fullPath, fileExtension, hash, and the csvFile are the parameters (method in AnalyzeFile.cs)
        }
    }

}


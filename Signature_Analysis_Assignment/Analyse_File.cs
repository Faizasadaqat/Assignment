using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Signature_Analysis_Assignment
{
    internal class Analyse_File
    {
        public string GetFileSignature(string path)
        {
            int bytesUsed = 4;
            byte[] buffer;
            using (FileStream filesStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader(filesStream))
                    buffer = binaryReader.ReadBytes(bytesUsed);
            }
            string fileSignature = BitConverter.ToString(buffer);
            return fileSignature.Replace("-", String.Empty).ToLower();
        }

        /// To Determine the file type from file signature
        public string GetFileType(string fileSignature)
        {
            if (fileSignature == "ffd8ffe0")
                return "This is a JPG file";
            else if (fileSignature == "25504446")
                return "This is a PDF file";
            else
                return "Other file";
        }

        // To returns the MD5 hash of the file contents of each file found
        public string GetMD5Hash(string path)
        {
            MD5 md5hash = MD5.Create();
            byte[] bytedata = md5hash.ComputeHash(Encoding.Default.GetBytes(path));
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < bytedata.Length; i++)
                stringBuilder.Append(bytedata[i].ToString("x2"));

            return stringBuilder.ToString();
        }

        // To Outputs the full path name of file, the fileExtention that determine if the file is PDF or JPG, and the MD5 Hash of each file to a CSV File
        public void CsvFill(string fullPath, string fileType, string hash, string csvFile)
        {
            string columnSeperator = ",";
            string[][] fileInformation = new string[][] { new string[] { fullPath, fileType, hash } };
            int length = fileInformation.GetLength(0);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
                sb.AppendLine(string.Join(columnSeperator, fileInformation[i]));

            File.AppendAllText(csvFile, sb.ToString());

        }
    }
}
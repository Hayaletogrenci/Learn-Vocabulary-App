using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelime_Ezberleme.Sınıflar
{
    public class FileSettings
    {
        public static string ReadFile()
        {
            string dosyaAdi = "localdatabase.txt"; // Determine the file name and file path
            string dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dosyaAdi);

            string text = "";
            if (File.Exists(dosyaYolu))
            {// If the file exists, read the file using StreamReader
                using (StreamReader streamReader = new StreamReader(dosyaYolu, Encoding.GetEncoding("iso-8859-9")))
                {// Read the entire file and assign it to the text variable
                    text = streamReader.ReadToEnd();
                }
            }// Return the read text
            return text;
        }

        public static List<string> ReadLinesOfFile(string filePath)
        {// Create a list to store the lines of the file
            List<string> lines = new List<string>();
            // Read the file using StreamReader
            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    lines.Add(line); // Add each line of the file to the list
            } // Return the list of lines
            return lines;
        }
    }
}

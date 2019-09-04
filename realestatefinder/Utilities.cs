using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realestatefinder
{
    class Utilities
    {
        static String documentPath = "startpagestate.info";

        public static void SaveToConfig(String key, String value)
        {
            // This text is added only once to the file.
            if (!File.Exists(documentPath))
            {
                (new FileInfo(documentPath)).Directory.Create();
                // Create a file to write to.
                File.WriteAllText(documentPath, key + ":" + value);
            }
            else
            {
                String existingValue = ReadFromConfig(key);
                if (existingValue != null && !existingValue.Equals(value))
                {

                    int lineNumber = GetLineToChange(key);
                    LineChanger(key + ":" + value, lineNumber);
                }
                else
                {
                    File.AppendAllText(documentPath, key + ":" + value);
                }

            }

        }

        static void LineChanger(string newLine, int lineNumber)
        {
            string[] arrLine = File.ReadAllLines(documentPath);
            arrLine[lineNumber] = newLine;
            try
            {
                File.WriteAllLines(documentPath, arrLine);
            }catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            
        }

        static int GetLineToChange(String key)
        {
            int counter = 0;
            string line;

            using (StreamReader reader = new StreamReader(documentPath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(key))
                    {
                        return counter;
                    }

                    counter++;
                }
            }               
            return -1;
        }

        public static String ReadFromConfig(String key)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line. 
            try
            {
                using (StreamReader reader = new StreamReader(documentPath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(key))
                        {
                            var keyValuePair = line.Split(':');
                            return keyValuePair[1];
                        }

                        counter++;
                    }

                }
            }
            catch (Exception e)
            {
                (new FileInfo(documentPath)).Directory.Create();
                return null;
            }
            return null;
            
        }

    }
}

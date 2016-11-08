using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GSU_EPAM_Autumn_2016
{
    class ReadAndWriteTofilePerString
    {
        public static string[] LoadFileInStringPerLineStrings(string fileName, string task)
        {
            //find file in working directory
            string substr = "bin\\debug";
            string filePatch = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                 .ToLower().Replace(substr, "")
                 + task + "\\" + fileName;

            string[] fileDataPerLine = null;
            #region read and write not null stribg from file
            try
            {
                int count = 0;
                #region Open file and count not null strings
                try
                {
                    //file open and count line.
                    using (StreamReader ins = new StreamReader(filePatch))
                    {
                        string line = ins.ReadLine();//read line
                        while (line != null)
                        {
                            if (line.Trim().Length > 0) //check line on empty
                            {
                                count++;
                            }
                            line = ins.ReadLine();
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("s: File is not open for read");
                }
                #endregion
                //generate string based on conut not null strings in file
                fileDataPerLine = new string[count];
                #region write all not null string from file
                try
                {
                    using (StreamReader ins = new StreamReader(filePatch))
                    {
                        string line = ins.ReadLine();
                        count = 0;
                        while (line != null)
                        {
                            line = line.Trim();//delete start end spases
                            if (line.Length > 0)
                            {
                                fileDataPerLine[count++] = line;
                            }
                            line = ins.ReadLine();
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("s: File is not open for read and write to file");
                    fileDataPerLine = null;
                }
                #endregion
                return fileDataPerLine;
            }
            catch (Exception)
            {
                Console.WriteLine("s: File is not open");
                return null;
            }
            #endregion
        }

        public static void SaveStringinFilePerLineStrings(string task, string[] inputStrings, string fileNameToWrite)
        {
            //find file in working directory
            string substr = "bin\\debug";
            string filePatch = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                 .ToLower().Replace(substr, "")
                 + task + "\\" + fileNameToWrite;
            #region Open file
            try
            {
                //file open to write
                using (StreamWriter ins = new StreamWriter(filePatch))
                {
                    foreach (var lineWrite in inputStrings)
                    {
                        ins.WriteLine(lineWrite);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("s: File is not open for read");
            }
            #endregion
        }
    }
}

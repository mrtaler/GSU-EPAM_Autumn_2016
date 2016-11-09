using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GSU_EPAM_Autumn_2016
{
    /// <summary>
    /// Class for read and write per string
    /// </summary>
    static class ReadAndWriteTofilePerString
    {
        /// <summary>
        /// Method for read file per string
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="task">Task</param>
        /// <returns>File data in array</returns>
        public static string[] LoadFileInStringPerLineStrings(string fileName, string task)
        {

            #region find file in working directory
            string substr = "bin\\debug";
            string filePatch = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                 .ToLower().Replace(substr, "")
                 + task + "\\" + fileName;
            #endregion
            #region read and write not null string from file
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
                //generate output array based on conut not null strings in file
                string[] fileDataPerLine = new string[count];
                #region write all not null string from file in output array
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
                    Console.WriteLine("File is not open for read and write to array");
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
        /// <summary>
        /// Method for write array in file per string
        /// </summary>
        /// <param name="task">Task</param>
        /// <param name="inputStrings">Input array</param>
        /// <param name="fileNameToWrite">File name for write</param>
        public static void SaveStringinFilePerLineStrings(string task, string[] inputStrings, string fileNameToWrite)
        {
            #region find file in working directory
            string substr = "bin\\debug";
            string filePatch = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                 .ToLower().Replace(substr, "")
                 + task + "\\" + fileNameToWrite;
            #endregion
            #region write array in to file
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
                Console.WriteLine("File is not open for write");
            }
            #endregion
        }
    }
}


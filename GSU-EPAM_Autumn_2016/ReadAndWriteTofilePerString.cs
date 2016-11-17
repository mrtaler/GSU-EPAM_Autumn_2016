using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GSU_EPAM_Autumn_2016
{ /// <summary>
  /// Class for read and write per string
  /// </summary>
    static class ReadAndWriteTofilePerString
    {
        /// <summary>
        /// Method for read file per string
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>File data in array</returns>
        public static string[] LoadFileInStringPerLineStrings(string fileName)
        {

            #region find file in working directory
            string substr = "bin\\debug";
            string filePatch = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                 .ToLower().Replace(substr, "")
                 + "\\" + fileName;
            #endregion



            string[] fileDataPerLine = new string[0];

            #region read and write not null string from file
            try
            {
                //file open and count line.
                using (StreamReader ins = new StreamReader(filePatch))
                {
                    int index = 0;
                    string fileData = null;
                    while ((fileData = ins.ReadLine()) != null)
                    {
                        Array.Resize(ref fileDataPerLine, fileDataPerLine.Length + 1);
                        fileDataPerLine[index] = fileData;
                        index++;
                    }
                    //  fileData = ins.ReadToEnd();
                }
                return fileDataPerLine;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("FileNotFoundException :" + ex.Message);
                Console.WriteLine("Trace :" + ex.StackTrace);
                return null;
            }
            #endregion
        }
        /// <summary>
        /// Method for write array in file per string
        /// </summary>
        /// <param name="inputStrings">Input array</param>
        /// <param name="fileNameToWrite">File name for write</param>
        public static void SaveStringinFilePerLineStrings(string[] inputStrings, string fileNameToWrite)
        {
            #region find file in working directory
            string substr = "bin\\debug";
            string filePatch = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                 .ToLower().Replace(substr, "")
                 + "\\" + fileNameToWrite;
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
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("DirectoryNotFoundException :" + ex.Message);
                Console.WriteLine("Trace :" + ex.StackTrace);
            }
            #endregion
        }
    }
}

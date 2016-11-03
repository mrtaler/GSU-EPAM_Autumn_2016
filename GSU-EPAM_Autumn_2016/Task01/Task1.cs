using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GSU_EPAM_Autumn_2016.Task01
{
    public class Task1
    {
        public Task1()
        {
            //Files name
            string[] fileNameaArray = new string[]
             {
                "Input1.csv",
                "Input2.csv",
                "Input3.csv",
                "Input4.csv",
                "Input5.csv",
                "Input6.csv"
             };
            //read all files
            foreach (var itemFileName in fileNameaArray)
            {

                Console.WriteLine("File is: " + itemFileName); //show file name with worked now
                string[] war = LoadFileInStringPerLineStrings(itemFileName); //read all file per line
                StringBuilder[] result = Task1(war); //work with file data in string

                //show result
                foreach (var itemRes in result)
                {
                    Console.WriteLine(itemRes);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadKey();


        }

        /// <summary>
        /// Method for loads csv in to string[] per line
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>csv in string</returns>
        private static string[] LoadFileInStringPerLineStrings(string fileName)
        {
            //find file in working directory
            string substr = "bin\\debug";
            string filePatch = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                 .ToLower().Replace(substr, "")
                 + "Task1\\" + fileName;

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
                catch (Exception exception)
                {
                    Console.WriteLine("s: " +
                        exception);
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
                catch (Exception exception)
                {
                    Console.WriteLine("s: " +
                exception);
                    fileDataPerLine = new string[]
                    {
                        "fail"
                    };

                }
                #endregion
                return fileDataPerLine;
            }
            catch (Exception exception)
            {
                fileDataPerLine = new string[]
                    {
                         "fail"
                    };
                Console.WriteLine("s: " +
                    exception);
                return fileDataPerLine;
            }
            #endregion
        }
        /// <summary>
        /// Method for count sum from string with using the pointer with the index 0 
        /// </summary>
        /// <param name="fileDataPerLineinString">File data in string</param>
        /// <returns>First: the amount of valid data</returns>
        /// <returns>Second: count of string with errors</returns>
        private static StringBuilder[] CountSummFromAllString(string[] fileDataPerLineinString)
        {
            double sumResult = 0;
            int stringErrorCount = 0;
            StringBuilder resultString = new StringBuilder();
            foreach (var item in fileDataPerLineinString)
            {
                int indexToWork = 0;
                string[] format = item.Split(';');//
                try
                {
                    indexToWork = Convert.ToInt32(format[0]);
                    try
                    {
                        //  Console.WriteLine(double.Parse(format[indexToWork].ToString()));
                        sumResult += double.Parse(format[indexToWork].ToString());
                        if (resultString.Length == 0)
                        {
                            resultString.Append("result(" + double.Parse(format[indexToWork].ToString()));
                        }
                        else if (double.Parse(format[indexToWork]) > 0)
                        {
                            resultString.Append(" + " + double.Parse(format[indexToWork].ToString()));
                        }
                        else if (double.Parse(format[indexToWork]) < 0)
                        {
                            resultString.Append(" - " + Math.Abs(double.Parse(format[indexToWork])).ToString());
                        }
                        else if (double.Parse(format[indexToWork]) == 0)
                        {
                            resultString.Append(" + 0.0");
                        }
                    }
                    catch (Exception)
                    {
                        //  Console.WriteLine("sumbol is not number");
                        stringErrorCount++;
                        if (resultString.Length == 0)
                            resultString.Append("result(");
                    }
                }
                catch (Exception)
                {
                    //Console.WriteLine("First sumbol is not number");
                    stringErrorCount++;
                }


            }
            return (new StringBuilder[2]
               {
                   resultString.Append(") = " + Math.Round(sumResult,2)),
                 new  StringBuilder("error-lines = "+stringErrorCount)
               });
        }
    }
}





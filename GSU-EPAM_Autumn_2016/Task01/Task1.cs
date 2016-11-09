using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GSU_EPAM_Autumn_2016;

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
                string[] fileDataPerString = ReadAndWriteTofilePerString.LoadFileInStringPerLineStrings(itemFileName, "Task01"); //read all file per line

                StringBuilder[] result = CountSummFromAllString(fileDataPerString); //work with file data in string

                //show result
                foreach (var itemRes in result)
                {
                    Console.WriteLine(itemRes);
                }
                Console.WriteLine();
            }
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
            #region Check input data for not null
            try
            {
                //work with input array per string
                foreach (var item in fileDataPerLineinString)
                {
                    int indexToWork = 0;
                    string[] format = item.Split(';');//split string using CSV Separator
                    #region check index[0] for valid data
                    try
                    {
                        indexToWork = Convert.ToInt32(format[0]); //find index
                        //if indexToWork is valid:
                        try
                        {
                            sumResult += double.Parse(format[indexToWork]);//adding valid finded number to sum result
                            #region output string builder
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
                            else if (Math.Abs(double.Parse(format[indexToWork])) < 1e-19)
                            {
                                resultString.Append(" + 0.0");
                            }
                            #endregion
                        }
                        catch (Exception)
                        {
                            stringErrorCount++;

                            //output strib builder
                            if (resultString.Length == 0)
                                resultString.Append("result(");
                        }
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine("First symbol is not number");
                        stringErrorCount++;
                    }
                    #endregion
                }
            }
            catch (Exception)
            {

                Console.WriteLine("input data is null");
                resultString.Append("result(");
            }
            #endregion
            #region return data
            return (new StringBuilder[2]
               {
                 resultString.Append(") = " + Math.Round(sumResult,2)), //first returned summ value in special format
                 new  StringBuilder("error-lines = "+stringErrorCount)  //second returned count error on special format
               });
            #endregion
        }
    }
}
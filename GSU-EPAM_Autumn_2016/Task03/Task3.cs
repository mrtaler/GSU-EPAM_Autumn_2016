using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GSU_EPAM_Autumn_2016.Task03
{
    public class Task3
    {
        public Task3()
        {
            string fileNameToRead = "Input1.csv";
            string fileNameToWrite = "Output1.csv";
            StringBuilder strResult = new StringBuilder();
            string resultFromStrB = "";
            string[] resultFromStrBArray;

            string commentPatternToEnd = @"(\/\*[^;]+\*\/)|(\/\*\*\/)|[/][/][^\n]+|([/][/]+)";
            int indexOfArray = 0;
            string[] stringFromFile = ReadAndWriteTofilePerString.LoadFileInStringPerLineStrings(fileNameToRead, "Task03"); //read all file per line in array

            foreach (var lineWrite in stringFromFile)
            {
                strResult.Append(lineWrite);
                strResult.Append('\n');
            }


            if (Regex.IsMatch(strResult.ToString(), commentPatternToEnd))
            {
                resultFromStrB = Regex.Replace(strResult.ToString(), commentPatternToEnd, "");
            }
            resultFromStrBArray = resultFromStrB.Split('\n');
            ReadAndWriteTofilePerString.SaveStringinFilePerLineStrings("Task03", resultFromStrBArray, fileNameToWrite);
        }
    }
}
// gjcktlybq [\/\/][^;]?\n+
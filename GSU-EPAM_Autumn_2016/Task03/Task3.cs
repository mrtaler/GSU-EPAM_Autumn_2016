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

            string resultFromStringBuilder = "";
            string[] resultFromStringBuilderArray;

            string commentPattern = @"(\/\*[^;]+\*\/)|(\/\*\*\/)|[/][/][^\n]+|([/][/]+)";
            string[] stringFromFile = ReadAndWriteTofilePerString.LoadFileInStringPerLineStrings(fileNameToRead,
                "Task03"); //read all file per line in array

            #region Union file data to string

            foreach (var lineWrite in stringFromFile)
            {
                strResult.Append(lineWrite);
                strResult.Append('\n');
            }

            #endregion

            #region Find pattern and replase

            if (Regex.IsMatch(strResult.ToString(), commentPattern))
            {
                resultFromStringBuilder = Regex.Replace(strResult.ToString(), commentPattern, "");
            }

            #endregion

            resultFromStringBuilderArray = resultFromStringBuilder.Split('\n');
            //split result to array for write in to file per string

            ReadAndWriteTofilePerString.SaveStringinFilePerLineStrings("Task03", resultFromStringBuilderArray,
                fileNameToWrite);
        }
    }
}

// gjcktlybq [\/\/][^;]?\n+
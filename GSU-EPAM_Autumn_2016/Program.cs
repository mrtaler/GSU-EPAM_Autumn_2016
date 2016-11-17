using GSU_EPAM_Autumn_2016;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GSU_EPAM_Autumn_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileNameToRead = "input.txt";
            string fileNameToWrite = "Output.txt";

            string commentPattern3 = @"([""].*?[""])|([\/][\*](\w|[^;])*?[\*][\/])|(([\/]{2,}.+)|\/\/)";//[""].*?[""]|([\/][\*](\w|[^;])*?[\*][\/])

            string[] stringFromFile = ReadAndWriteTofilePerString.LoadFileInStringPerLineStrings(fileNameToRead); //read all file per line in array
            #region UNION all strigs in 1 mega string
            StringBuilder strResult = new StringBuilder();

            foreach (var VARIABLE in stringFromFile)
            {
                strResult.Append(VARIABLE);
                strResult.Append('\n');
            }
            #endregion

            string resultFromStringBuilder = "";

            if (Regex.IsMatch(strResult.ToString(), commentPattern3))
            {
                resultFromStringBuilder = Regex.Replace(strResult.ToString(), commentPattern3, matcher);
            }

            string[] resultFromStringBuilderArray = resultFromStringBuilder.Split('\n'); //split result to array for write in to file per string

            ReadAndWriteTofilePerString.SaveStringinFilePerLineStrings(resultFromStringBuilderArray,
                fileNameToWrite);
        }
        /// <summary>
        /// method for find only comment
        /// </summary>
        /// <param name="match">string or comment</param>
        /// <returns>empty string if comment find</returns>
        private static string matcher(Match match)
        {
            if (!match.ToString().StartsWith("\""))
            {
                return "";
            }
            else
            {

                return match.Value;
            }
        }
    }
}
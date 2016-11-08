using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GSU_EPAM_Autumn_2016.Task02
{
    public class Task2
    {
        public Task2()
        {

            string fileNameToRead = "Input1.csv";
            string fileNameToWrite = "Output1.csv";

            string[] stringFromFile = ReadAndWriteTofilePerString.LoadFileInStringPerLineStrings(fileNameToRead, "Task02"); //read all file per line in array

            DateChangerUniversalChange date = new DateChangerUniversalChange();

            string datePatten = @"\b((0[1-9]|[12][0-9]|3[01])|[1-9])[-/.]((0[1-9]|1[012])|[1-9])[-/.]((19|20\d\d)|(\d\d))\b";
            string[] ResultData = date.ReplasePatternPerString(stringFromFile, datePatten);


            BlrRubleChangeUniversalChange blr = new BlrRubleChangeUniversalChange();
            string blrRublePattern = @"(\b[^a-zA-Z.]+ blr.)|(\b[^a-zA-Z]+ belarusian roubles)";
            string[] ResultMoney = blr.ReplasePatternPerString(ResultData, blrRublePattern);

            ReadAndWriteTofilePerString.SaveStringinFilePerLineStrings("Task02", ResultData, fileNameToWrite);
        }
        static string dateToUsFormat(string input, string patternReplase)
        {
            return "";
        }
    }
}
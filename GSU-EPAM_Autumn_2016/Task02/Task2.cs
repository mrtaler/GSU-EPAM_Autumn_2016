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

            string[] stringFromFile = ReadAndWriteTofilePerString.LoadFileInStringPerLineStrings(fileNameToRead, "Task02"); //read all file per line in to array

            #region datatime change
            DateChangerUniversalChange date = new DateChangerUniversalChange();

            string dataTimePatten = @"\b((0[1-9]|[12][0-9]|3[01])|[1-9])[-/.]((0[1-9]|1[012])|[1-9])[-/.]((19|20\d\d)|(\d\d))\b";
            string[] resultAfterDataChange = date.ReplasePatternPerString(stringFromFile, dataTimePatten);//result after datatime change
            #endregion

            #region blr change
            BlrRubleChangeUniversalChange blr = new BlrRubleChangeUniversalChange();

            string blrRublePattern = @"(\b[^a-zA-Z.]+ blr.)|(\b[^a-zA-Z]+ belarusian roubles)";

            string[] resultAfterMoneyChange = blr.ReplasePatternPerString(resultAfterDataChange, blrRublePattern);
            #endregion
            ReadAndWriteTofilePerString.SaveStringinFilePerLineStrings("Task02", resultAfterMoneyChange, fileNameToWrite);//write array if file
        }
    }
}
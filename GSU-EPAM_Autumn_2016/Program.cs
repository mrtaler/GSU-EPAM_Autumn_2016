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
            {
                string fileNameToRead = "input.txt";
                string fileNameToWrite = "Output.txt";





                string commentPattern1 = @"(?<=[;]| )(([\/]{2,}.+)|\/\/)";// for // comment
                                                                          //
                                                                          //  string commentPattern2 = @"([\/][\*](\w|\P{L})*?[\*][\/])";
                string commentPattern3 = @"[""].*?[""]|([\/][\*](\w|[^;])*?[\*][\/])";//[""].*?[""]|([\/][\*](\w|[^;])*?[\*][\/])

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
                #region Delete all end string comment, after ;//
                if (Regex.IsMatch(strResult.ToString(), commentPattern1))
                {
                    resultFromStringBuilder = Regex.Replace(strResult.ToString(), commentPattern1, "");
                    var t = resultFromStringBuilder;
                }
                #endregion

                if (Regex.IsMatch(resultFromStringBuilder, commentPattern3))
                {
                    resultFromStringBuilder = Regex.Replace(resultFromStringBuilder, commentPattern3, matcher);
                }

                string[] resultFromStringBuilderArray = resultFromStringBuilder.Split('\n'); //split result to array for write in to file per string

                ReadAndWriteTofilePerString.SaveStringinFilePerLineStrings(resultFromStringBuilderArray,
                    fileNameToWrite);
            }
        }

        private static string matcher(Match match)
        {
            if (!Regex.IsMatch(match.ToString(), @"[""].*?[""]"))
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
// for /**/ comment ([\/][\*](\w|\P{L})*?[\*][\/])

//string s = "\t";/**/*//*    /**//*
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
            string fileName = "Input1.csv";
            string[] stringFromFile = Program.LoadFileInStringPerLineStrings(fileName, "Task02"); //read all file per line

            string datePatten = @"\b((0[1-9]|[12][0-9]|3[01])|[1-9])[-/.]((0[1-9]|1[012])|[1-9])[-/.]((19|20\d\d)|(\d\d))\b";
            Regex reg = new Regex(datePatten, RegexOptions.IgnoreCase);
            foreach (var itemString in stringFromFile)
            {

                //   stringFromFile = Regex.Replace(stringFromFile, datePatten, "replacement1");
                MatchCollection mc = reg.Matches(itemString);

                foreach (Match mat in mc)
                {
                    string finDate = (mat.Value.ToString());

                    DateTime newDate = DateTime.Parse(finDate);

                    Console.Write(mat.ToString() + '\t' + " new:");
                    Console.WriteLine(newDate.Date.ToString());
                }
            }

            //    Program.SaveStringinFilePerLineStrings("output", "Task02");
        }
        static string dateToUsFormat(string input, string patternReplase)
        {
            try
            {

                return Regex.Replace(input,
                      patternReplase,
                       "${day}-${month}-${year}", RegexOptions.None,
                       TimeSpan.FromMilliseconds(150));
            }
            catch (RegexMatchTimeoutException)
            {
                return input;
            }
        }
    }
}
//([0-3][1-9]|[0-9])[-/.](\d{2}|\d{1})[-/.](\d{4}\b|\d{2})
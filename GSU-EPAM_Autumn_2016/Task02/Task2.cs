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
            string[] war = Program.LoadFileInStringPerLineStrings(fileName, "Task02"); //read all file per line

            //Regex reg = new Regex(@"((\d{2})|(\d))\/((\d{2})|(\d))\/((\d{4})|(\d{2}))", RegexOptions.IgnoreCase);
            Regex reg = new Regex(@"(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))", RegexOptions.IgnoreCase);


            foreach (var itemString in war)
            {
                MatchCollection mc = reg.Matches(itemString);

                foreach (Match mat in mc)
                {
                    Console.WriteLine(mat.ToString());
                }

            }



        }

    }

}

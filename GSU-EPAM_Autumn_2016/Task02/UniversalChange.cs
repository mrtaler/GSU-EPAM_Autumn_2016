using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Task02
{
    public abstract class UniversalChange
    {
        protected UniversalChange()
        {
        }
        public string[] ReplasePatternPerString(string[] inputStrings, string patternFind)
        {
            try
            {
                int indexOfArray = 0;
                foreach (var lineWrite in inputStrings)
                {
                    if (Regex.IsMatch(lineWrite, patternFind))
                    {
                        inputStrings[indexOfArray] = Regex.Replace(lineWrite, patternFind, Changer);
                    }
                    indexOfArray++;
                }
                return inputStrings;
            }
            catch (Exception)
            {
                Console.WriteLine("error");
                return inputStrings;
            }
        }
        protected abstract string Changer(Match match);
    }
}



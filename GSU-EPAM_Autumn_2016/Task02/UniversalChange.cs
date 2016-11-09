using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Task02
{
    /// <summary>
    /// Abstract class for replace the mask on line
    /// </summary>
    public abstract class UniversalChange
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        protected UniversalChange()
        {
        }
        /// <summary>
        /// Method for replase in string by pattern
        /// </summary>
        /// <param name="inputStrings">Input array</param>
        /// <param name="patternFind">search and replase pattern</param>
        /// <returns>array with the replacement for the pattern</returns>
        public string[] ReplasePatternPerString(string[] inputStrings, string patternFind)
        {
            try
            {
                int indexOfArray = 0;
                foreach (var lineWrite in inputStrings) //work per string with input data 
                {
                    if (Regex.IsMatch(lineWrite, patternFind)) //find matches by pattern
                    {
                        inputStrings[indexOfArray] = Regex.Replace(lineWrite, patternFind, Changer);//replase matches
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
        /// <summary>
        /// abstract method for replase data
        /// </summary>
        /// <param name="match">Match</param>
        /// <returns>replasement string</returns>
        protected abstract string Changer(Match match);
    }
}
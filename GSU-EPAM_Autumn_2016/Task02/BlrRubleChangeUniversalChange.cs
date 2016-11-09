using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace GSU_EPAM_Autumn_2016.Task02
{
    /// <summary>
    /// Class for BlrRouble change 
    /// </summary>
    class BlrRubleChangeUniversalChange : UniversalChange
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BlrRubleChangeUniversalChange()
            : base()
        {
        }
        /// <summary>
        /// Overrided method for Blr Change
        /// </summary>
        /// <param name="match">Blr pattern match</param>
        /// <returns>blr without spaces</returns>
        protected override string Changer(Match match)
        {
            try
            {
                StringBuilder tempDigit = new StringBuilder("");
                //find all digit
                var digit = Regex.Matches(match.Value.ToString(), @"\d+");
                #region delete spaces in digit data  
                foreach (var item in digit)
                {
                    tempDigit.Append(item.ToString());
                }
                #endregion
                var ww = tempDigit.ToString() + " ";
                //find all digit with spaces and replace without spaces
                string result = Regex.Replace(match.Value.ToString(), @"(\b[^a-zA-Z.]+ )", ww);
                return result;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception to delete spaces in summ");
                return "Error";
            }
        }
    }
}

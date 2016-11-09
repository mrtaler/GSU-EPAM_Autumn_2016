using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace GSU_EPAM_Autumn_2016.Task02
{
    /// <summary>
    /// Class for convert data in US long DataTime format
    /// </summary>
    class DateChangerUniversalChange : UniversalChange
    {
        //default constructor
        public DateChangerUniversalChange()
            : base()
        {
        }
        /// <summary>
        /// method for convert input Data matches to US long DataTime format
        /// </summary>
        /// <param name="match">DataTime maches</param>
        /// <returns>DataTime in US long data format</returns>
        protected override string Changer(Match match)
        {
            try
            {
                DateTime tmp = DateTime.Parse(match.Value);//convert input match to data format
                return tmp.ToString("MMMM dd, yyyy", new CultureInfo("en-US"));
            }
            catch (Exception)
            {
                return "error convert data";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace GSU_EPAM_Autumn_2016.Task02
{
    class BlrRubleChangeUniversalChange : UniversalChange
    {

        public BlrRubleChangeUniversalChange()
            : base()
        {
        }

        protected override string Changer(Match match)
        {
            try
            {
                StringBuilder tempDigit = new StringBuilder("");
                var digit = Regex.Matches(match.Value.ToString(), @"\d+");
                foreach (var item in digit)
                {
                    tempDigit.Append(item.ToString());
                }
                var ww = tempDigit.ToString() + " ";
                string result = Regex.Replace(match.Value.ToString(), @"(\b[^a-zA-Z.]+ )", ww);
                // if (result.IndexOf(" ") > 2)
                //  { 
                return result;
                //  }
                // else
                //   {
                //    StringBuilder temp = new StringBuilder("");
                //    int index = result.IndexOf('b');
                //    temp.Append(result.Substring(0, index));
                //    temp.Replace(" ", "");
                //    temp.Append(result.Substring(result.IndexOf("b") - 1));
                //    return (" "+temp.ToString());
                //}

            }
            catch (Exception)
            {

                Console.WriteLine("Exception to delete spaces in summ");
                return "Error";
            }
        }
    }
}

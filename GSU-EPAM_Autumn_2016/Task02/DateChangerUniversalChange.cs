using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace GSU_EPAM_Autumn_2016.Task02
{
    class DateChangerUniversalChange : UniversalChange
    {
        public DateChangerUniversalChange()
            : base()
        {
        }

        protected override string Changer(Match match)
        {
            DateTime tmp = DateTime.Parse(match.Value);
            return tmp.ToString("D", new CultureInfo("en-US"));
        }
    }
}

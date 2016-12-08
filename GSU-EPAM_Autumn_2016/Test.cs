using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace GSU_EPAM_Autumn_2016
{
    /// <summary>
    /// Student test class 
    /// </summary>
    class Test
    {
        private string test;
        private DateTime date;
        private int mark;
        /// <summary>
        /// Constructor for take data in xml
        /// </summary>
        /// <param name="testFromXlm">XML Test Data</param>
        public Test(XElement testFromXlm)
        {
            test = testFromXlm.Attribute("name").Value;
            date = DateTime.Parse(testFromXlm.Attribute("date").Value.ToString());
            mark = Convert.ToInt32(Convert.ToDouble((testFromXlm.Attribute("mark").Value).Replace('.', ',')) * 10);
        }
        /// <summary>
        /// Method for print Test Data with separator ";"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string datt = date.ToString("yyyy-MM-dd");
            return (
                String.Format(
                "{0,-5};{1,-10};{2,0}.{3,0}", test, datt, (mark / 10), (mark % 10))
                );
        }
    }
}

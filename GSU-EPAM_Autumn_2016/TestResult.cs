using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace GSU_EPAM_Autumn_2016
{
    /// <summary>
    /// Class Student TestResult
    /// </summary>
    class TestResult
    {
        private string login;
        private List<Test> testList;

        /// <summary>
        /// Constructor for take Student data from XML
        /// </summary>
        /// <param name="testResultFromXlm">Student data from XML</param>
        public TestResult(XElement testResultFromXlm)
        {
            testList = new List<Test>();//make list for student test
            login = testResultFromXlm.Element("login").Value.ToString();//Student login
            foreach (var item in testResultFromXlm.Element("tests").Elements("test")) //find all student test
            {
                testList.Add(new Test(item));
            }
        }
        /// <summary>
        /// Method for print Student data with Separator ";"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder strBld = new StringBuilder();
            foreach (var item in testList)
            {
                strBld.Append(login); strBld.Append(";");
                strBld.Append(item.ToString());
                strBld.Append("\n");
            }
            return strBld.ToString();
        }
    }
}

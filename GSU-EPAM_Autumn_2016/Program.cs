using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GSU_EPAM_Autumn_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TestResult> TestResultList = new List<TestResult>();
            XDocument xdoc = XDocument.Load("results.xml");

            foreach (var item in xdoc.Root.Elements("student"))//find all student in XML file
            {
                TestResultList.Add(new TestResult(item));
            }
            //print all student data
            foreach (var item in TestResultList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSU_EPAM_Autumn_2016.Base;

namespace GSU_EPAM_Autumn_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchaseCollection prColl = new PurchaseCollection(args[0]);



            foreach (var VARIABLE in prColl.PurchaseList)
            {
                Console.WriteLine(VARIABLE);
            }
            Console.ReadKey();
        }
    }
}

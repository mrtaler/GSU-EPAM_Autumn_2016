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
            // Load data from main file
            PurchaseCollection mainColl = new PurchaseCollection(args[0]);
            mainColl.PrintCollection("After create");

            // Load data from add file
            PurchaseCollection addColl = new PurchaseCollection(args[1]);

            // insert last element addColl to index [0] in mainColl
            mainColl.Insert(0, addColl.PurchaseList.Last());

            // Insert first element addColl to index pos [1000] in main coll;
            mainColl.Insert(1000, addColl.PurchaseList.First());

            // Insert element in index pos [2] addColl to index pos [2] in main coll
            mainColl.Insert(2, addColl.PurchaseList[2]);
            // Delete from main Coll 
            mainColl.Delete(3);
            mainColl.Delete(10);
            mainColl.Delete(-5);

            mainColl.PrintCollection("Before sort");
            Console.WriteLine();

            // Main collection sort by PurchaseSort()
            mainColl.Sort(new PurchaseSort());
            mainColl.PrintCollection("After sort");
            Console.WriteLine();


            var elementFind = addColl.PurchaseList[1];
            int indexSearch = mainColl.PurchaseList.BinarySearch(elementFind, new PurchaseSort());

            #region Find in maain coll element with index 1 from add coll
            Console.WriteLine("Element ");
            Console.WriteLine("\t" + elementFind);
            if (indexSearch > 0)
            {
                Console.WriteLine("found at position " + indexSearch);
                indexSearch = -1;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("  not found");
                indexSearch = -1;
                Console.WriteLine();
            }
            #endregion
            #region Find in maain coll element with index 1 from add coll

            elementFind = addColl.PurchaseList[3];
            indexSearch = mainColl.PurchaseList.BinarySearch(elementFind, new PurchaseSort());

            Console.WriteLine("Element ");
            Console.WriteLine("\t" + elementFind);

            if (indexSearch > 0)
            {
                Console.WriteLine("found at position " + indexSearch);
                indexSearch = -1;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("  not found");
                indexSearch = -1;
                Console.WriteLine();
            }
            #endregion

            Console.ReadKey();
        }
    }
}

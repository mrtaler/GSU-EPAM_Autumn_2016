using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSU_EPAM_Autumn_2016.Task02
{
    public class Task2
    {
        public Task2()
        {
            Console.WriteLine("----------------------------------1----------------------------------");
            AbstractPurchase[] pofg = new AbstractPurchase[] 
            {
                new PurchaseWithDiscountToCostAbstractPurchase("T1",6.85M,15,1.35M),
                new PurchaseWithDiscountToCostAbstractPurchase("T2",7.85M,17,2.05M),
                new PurchaseWithDiscountToCountAbstractPurchase("T3",9.54M,43,12),
                new PurchaseWithDiscountToCountAbstractPurchase("T4",8.54M,21,5),
                new PurchaseWithTransportationCostsAbstractPurchase("T5",3.53M,4,21),
                new PurchaseWithTransportationCostsAbstractPurchase("T6",1.34M,14,2)
            };
            Console.WriteLine("----------------------------------2----------------------------------");
            print(pofg);


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------------------------3----------------------------------");
            Array.Sort(pofg);
            Console.WriteLine("----------------------------------4----------------------------------");
            print(pofg);
        }
        private void print(AbstractPurchase[] printList)
        {
            foreach (var item in printList)
            {
                Console.WriteLine(item);
            }
        }
    }
}

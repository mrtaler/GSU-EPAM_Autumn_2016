using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Task3
{
    public class Task03
    {
        public Task03()
        {
            //-----------------------1-------------------------------
            Console.WriteLine("-----------------------1-------------------------------");
            //new array of Purchase
            Purchase[] allPurchases = new Purchase[]
           {
               new Purchase("tools",2.75,12, DayOfWeek.Sunday ),
               new Purchase("gun",3.75,30, DayOfWeek.Monday ),
               new Purchase("ammo",13.75,113, DayOfWeek.Saturday ),
               new Purchase("armor",7.75,23, DayOfWeek.Saturday ),
               new Purchase("food",8.75,34, DayOfWeek.Thursday ),
           };
            //-----------------------2-------------------------------
            //show array with overrided method "ToString();
            Console.WriteLine("-----------------------2-------------------------------");
            foreach (var VARIABLE in allPurchases)
            {
                Console.WriteLine(VARIABLE.ToString());
            }
            Console.WriteLine();
            //-----------------------3-------------------------------
            //find average cost all purchase, find day of max purchase
            Console.WriteLine("-----------------------3-------------------------------");
            double summAllCost = 0;
            int countOfPurchase = 0;
            Purchase maxPurchase = allPurchases[0];
            foreach (var VARIABLE in allPurchases)
            {
                #region Find max purchase
                if (VARIABLE.CompareTo(maxPurchase) == 1)
                {
                    maxPurchase = VARIABLE;
                }
                #endregion
                summAllCost += VARIABLE.PurchaseCost;
                countOfPurchase++;
            }
            double averageCost = summAllCost / countOfPurchase; //find average cost all purchase

            Console.WriteLine("average cost is: " + averageCost.ToString());//average cost
            Console.WriteLine("day of max purchase Cost is: " + maxPurchase.DayOfPurchase) ;//day of max purchaseCost
            Console.WriteLine();
            //-----------------------4-------------------------------
            //Sort with Array method
            Console.WriteLine("-----------------------4-------------------------------");
            Array.Sort(allPurchases);

            //-----------------------5-------------------------------
            //Show sorted array 
            Console.WriteLine("-----------------------5-------------------------------");
            foreach (var VARIABLE in allPurchases)
            {
                Console.WriteLine(VARIABLE.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSU_EPAM_Autumn_2016.Task01
{
    public class Task1
    {
        public Task1()
        {
            Console.WriteLine("----------------------------------1----------------------------------");

            #region Array not equal
            PurchaseOfGoods[] pofg = new PurchaseOfGoods[]
            {
                  new PurchaseWithFixDiscountPurchaseOfGoods("Purchase 1", 10, 20.33M, 7.5M),
                  new PurchaseWithFixDiscountPurchaseOfGoods("Purchase 2", 4, 35.89M, 35M),
                  new PurchaseOfGoods("Purchase 2", 3, 35.89M),
                  new PurchaseOfGoods("Purchase 4", 4, 01.30M),
                  new PurchaseWithDiscountToCountPurchaseOfGoods("Purchase 3", 7, 35.87M, 35M),
                  new PurchaseWithDiscountToCountPurchaseOfGoods("Purchase 4", 4, 01.30M, 35M)
            };
            #endregion
            #region equal array
            //  PurchaseOfGoods[] pofg = new PurchaseOfGoods[]
            //  {
            //      new PurchaseWithFixDiscountPurchaseOfGoods("Purchase 1", 10, 20.33M, 73M),
            //      new PurchaseWithFixDiscountPurchaseOfGoods("Purchase 1", 122, 20.33M, 73M),
            //      new PurchaseOfGoods("Purchase 1", 41,  20.33M),
            //      new PurchaseOfGoods("Purchase 1", 61, 20.33M),
            //      new PurchaseWithDiscountToCountPurchaseOfGoods("Purchase 1", 1, 20.33M, 73M),
            //      new PurchaseWithDiscountToCountPurchaseOfGoods("Purchase 1", 1, 20.33M, 71M)

            //};
            #endregion
            Console.WriteLine("--------------------------------2 - 4--------------------------------");

            // этот массив нужен был для хранения одинаковых покупок
            // PurchaseOfGoods[] equals = new PurchaseOfGoods[0]
            // явный вызов ToString() для полей класса при переопределении метода был использован по привычке.

            ;

            int indexin = 0;
            int countEqual = 1;
            PurchaseOfGoods maxPurchase = pofg[0];
            foreach (var item in pofg)
            {
                #region sub task 3: find max purchase
                if (item.CostOfGoods > maxPurchase.CostOfGoods)
                {
                    maxPurchase = item;
                }
                #endregion
                #region sub task 4: find equals purchase
                //{
                indexin++;
                if (indexin < pofg.Length && item.Equals(pofg[indexin]))
                {
                    countEqual++;
                }
                //}
                #endregion
                //sub task 2: show elements     
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------show equals element-------------------------");
            #region sub task4: show equals element

            Console.WriteLine(
                countEqual == pofg.Length ?
                "all purchases eqal" :
                "Purchases are not eqal"
                );
            //данный участок выводит повторяющиеся покупки
            //foreach (var item in equals)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            Console.WriteLine();
            //sub task 3: show max purchase
            Console.WriteLine("maxPurchase is: " + maxPurchase);
        }
    }
}

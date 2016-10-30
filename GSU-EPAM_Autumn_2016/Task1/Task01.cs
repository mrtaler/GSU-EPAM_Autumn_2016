using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Task1
{
    public class Task01
    {
        public Task01()
        {
            //-----------------------1-------------------------------

            #region new array of  5 Travel Expenses, 2 element is null,last element is default 
            Console.WriteLine("-----------------------1-------------------------------");
            TravelExpenses[] txEx = new[]
              {
                new TravelExpenses("Sara Zigenbah ", 23.75, 8),
                null,
                new TravelExpenses("Gans Ihbolt", 3.75, 5),
                new TravelExpenses("Roberto bi Rodriges", 10.25, 11),
                new TravelExpenses()
            };

            #endregion

            //-----------------------2-------------------------------
            Console.WriteLine("-----------------------2-------------------------------");
            #region Show in console with method "Show()"

            foreach (var VARIABLE in txEx)
            {
                if (VARIABLE != null) //check for null
                {
                    VARIABLE.Show();
                    Console.WriteLine();
                }
            }

            #endregion

            //-----------------------3-------------------------------
            // Change Transport Expenses in last element
            Console.WriteLine("-----------------------3-------------------------------");
            txEx.Last().TransportExpenses = 2.25;
            Console.WriteLine();
            //-----------------------4-------------------------------

            #region show duration of 2 first travel 
            Console.WriteLine("-----------------------4-------------------------------");
            int Current = 0;
            int duration = 0;
            foreach (var VARIABLE in txEx)
            {

                if (VARIABLE != null && Current <= 2)
                    duration += VARIABLE.DayTotal;
                Current += 1;
            }
            Console.WriteLine("duration first 2 Travel is " + duration.ToString() + " days");

            #endregion

            //-----------------------5-------------------------------

            #region Show in console with override method "ToString()"
            Console.WriteLine("-----------------------5-------------------------------");
            foreach (var VARIABLE in txEx)
            {
                if (VARIABLE != null) Console.WriteLine(VARIABLE.ToString());
            }
            #endregion
        }
    }
}

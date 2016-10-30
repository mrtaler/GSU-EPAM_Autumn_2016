using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Task1
{
    /// <summary>
    /// Class for travel expenses
    /// </summary>
    public class TravelExpenses
    {
        private const double dailyExpenses = 22.5;
        #region Last and First Name
        private string lastFirstName;
        public string LastFirstName
        {
            get
            {
                return lastFirstName;
            }

            set
            {
                if (lastFirstName!=value)
                lastFirstName = value;
            }
        }
#endregion
        #region Transport Expenses
        private double transportExpenses;
        public double TransportExpenses
        {
            get
            {
                return transportExpenses;
            }

            set
            {
                if (transportExpenses != value)
                    transportExpenses = value;
            }
        }
        #endregion
        #region Total Day  of Travel
        int dayTotal;
        public int DayTotal
        {
            get
            {
                return dayTotal;
            }

            set
            {
                if (dayTotal != value)
                    dayTotal = value;
            }
        }
        #endregion
        public double Total
        {
            get
            {
                return GetTotal();
            }
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public TravelExpenses()
        {
            LastFirstName = "Jon Doe";
            transportExpenses = 13.3;
            DayTotal = 3;
        }
        /// <summary>
        /// Сonstructor with Param
        /// </summary>
        /// <param name="LastFirstName"> Last and First name (separated by a space)</param>
        /// <param name="TransportExpenses">Transport expenses </param>
        /// <param name="DayTotal"> amount of days of travel</param>
        public TravelExpenses(  string LastFirstName,
                                double TransportExpenses,
                                int DayTotal)
        {
            this.LastFirstName = LastFirstName;
            this.TransportExpenses = TransportExpenses;
            this.DayTotal = DayTotal;
        }
        /// <summary>
        /// Method for calc all of Transport Expenses 
        /// </summary>
        /// <returns>all Transport Expenses</returns>
        public double GetTotal()
        {
            return (transportExpenses + DayTotal * dailyExpenses);
        }
        /// <summary>
        /// Method for Show instance of the class
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Last First Name =" + LastFirstName);
            Console.WriteLine("Daily Expenses =" + dailyExpenses.ToString());
            Console.WriteLine("Transport Expenses =" + transportExpenses.ToString());
            Console.WriteLine("Day Total =" + DayTotal.ToString());
            Console.WriteLine("Total =" + Total.ToString());
        }
        /// <summary>
        /// Method for show instance of the class in csv format
        /// </summary>
        /// <returns>csv separated by ; </returns>
        public override string ToString()
        {
            return LastFirstName + ";" + "\t" +
                dailyExpenses + ";" + "\t" +
                transportExpenses + ";" + "\t" +
                DayTotal + ";" + "\t" +
                Total;

        }
    }
}

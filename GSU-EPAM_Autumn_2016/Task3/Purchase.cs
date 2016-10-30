using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Task3
{
    /// <summary>
    /// enum for day of week
    /// </summary>
    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    /// <summary>
    /// Purchase class with IComparable
    /// </summary>
    public class Purchase : IComparable<Purchase>
    {
        #region Name
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                }
            }
        }
        #endregion
        #region Cost
        private double cost;
        public double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                if (cost != value)
                {
                    cost = value;
                }
            }
        }
        #endregion
        #region Quantity
        private int quantity;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                }
            }
        }
        #endregion
        #region DayOfPurchase

        private DayOfWeek dayOfPurchase;
        public DayOfWeek DayOfPurchase
        {
            get
            {
                return dayOfPurchase;
            }
            set
            {
                if (dayOfPurchase != value)
                {
                    dayOfPurchase = value;
                }
            }
        }

        #endregion
        public double PurchaseCost
        {
            get
            {
                return GetCost();
            }
        }
        /// <summary>
        /// default constructor
        /// </summary>
        public Purchase()
        {
            Name = "fuel";
            Cost = 12.5;
            Quantity = 42;
            DayOfPurchase = DayOfWeek.Sunday;
        }
        /// <summary>
        /// Constructor with param
        /// </summary>
        /// <param name="Name">Name Of Purchase</param>
        /// <param name="Cost">Cost of Purchase</param>
        /// <param name="Quantity">Quanity of Purchase</param>
        /// <param name="DayOfPurchase">Purchase Day</param>
        public Purchase(string Name, double Cost, int Quantity, DayOfWeek DayOfPurchase)
        {
            this.Name = Name;
            this.Cost = Cost;
            this.Quantity = Quantity;
            this.DayOfPurchase = DayOfPurchase;
        }
        /// <summary>
        /// method for calc summ cost of item
        /// </summary>
        /// <returns>Cost of item</returns>
        public double GetCost()
        {
            return cost * quantity;
        }
        /// <summary>
        /// compare 2 purchase
        /// </summary>
        /// <param name="other">purchase to compare</param>
        /// <returns>1 if less,-1 if more, 0 in any else</returns>
        public int CompareTo(Purchase other)
        {
            if (this.PurchaseCost > other.PurchaseCost)
                return 1;
            if (this.PurchaseCost < other.PurchaseCost)
                return -1;
            else
                return 0;
        }
        /// <summary>
        /// Overrided method to show in CSV
        /// </summary>
        /// <returns>CSV with separator ";"</returns>
        public override string ToString()
        {
            return (
                name + ";" + "\t" +
                cost.ToString() + ";" + "\t" +
                quantity.ToString() + ";" + "\t" +
                DayOfPurchase.ToString() + ";" + "\t" +
                PurchaseCost.ToString());

        }
    }
}

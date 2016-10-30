using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSU_EPAM_Autumn_2016.Task02
{
    public abstract class AbstractPurchase : IComparable<AbstractPurchase>
    {
        private Commodity comodity;
        public Commodity Comodity
        {
            get
            {
                return comodity;
            }
            set
            {
                comodity = value;
            }
        }
        private int quantityOfcomodity;
        public int QuantityOfcomodity
        {
            get
            {
                return quantityOfcomodity;
            }
            set
            {
                quantityOfcomodity = value;
            }
        }
        public decimal CostOfGoods
        {
            get
            {
                return GetCost();
            }
        }
        /// <summary>
        /// default constructor
        /// </summary>
        public AbstractPurchase()
        {
            comodity = null;
            quantityOfcomodity = 0;
        }
        /// <summary>
        /// constructor with param
        /// </summary>
        /// <param name="comodity">new Comodity</param>
        /// <param name="quantityOfcomodity">Quantity</param>
        public AbstractPurchase(Commodity comodity, int quantityOfcomodity)
        {
            this.comodity = comodity;
            this.quantityOfcomodity = quantityOfcomodity;
        }
        /// <summary>
        /// abstract method for calc cost of purchase
        /// </summary>
        /// <returns>Cost (BYN)</returns>
        public abstract decimal GetCost();
        /// <summary>
        /// Overrided method to show in CSV
        /// </summary>
        /// <returns>CSV with separator ";"</returns>
        public override string ToString()
        {
            return (
                comodity + ";" + '\t' +
                quantityOfcomodity + ";" + '\t' +
                CostOfGoods
                );
        }
        /// <summary>
        /// compare 2 purchase
        /// </summary>
        /// <param name="other">purchase to compare</param>
        /// <returns>1 if more,-1 if less, 0 in any else</returns>
        public int CompareTo(AbstractPurchase other)
        {
            if (this.CostOfGoods < other.CostOfGoods)
                return 1;
            if (this.CostOfGoods > other.CostOfGoods)
                return -1;
            else
                return 0;
        }
    }
}

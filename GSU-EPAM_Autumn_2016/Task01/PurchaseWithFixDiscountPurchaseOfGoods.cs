using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSU_EPAM_Autumn_2016.Task01
{
    /// <summary>
    /// Class for Purchase With Fix Discount to Price
    /// </summary>
    class PurchaseWithFixDiscountPurchaseOfGoods : PurchaseOfGoods
    {
        private decimal discount;
        public decimal Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
            }
        }
        /// <summary>
        /// Basic constructor 
        /// </summary>
        public PurchaseWithFixDiscountPurchaseOfGoods()
            : base()
        {
            discount = 0;
        }

        /// <summary>
        /// Constructor with param
        /// </summary>
        /// <param name="productName">Name of product</param>
        /// <param name="quantityOfGoods">Quanity</param>
        /// <param name="price">Price (BYN)</param>
        /// <param name="discount">Discount (BYN)</param>
        public PurchaseWithFixDiscountPurchaseOfGoods(string productName, int quantityOfGoods, decimal price, decimal discount)
            : base(productName, quantityOfGoods, price)
        {
            this.discount = discount;
        }
        /// <summary>
        /// Overrided method to show in CSV
        /// </summary>
        /// <returns>CSV with separator ";"</returns>
        public override string ToString()
        {
            return
                (
                base.ToString() + ";" + '\t' + '\t'
                + discount
                );
        }
        /// <summary>
        /// Method for calc product cost
        /// </summary>
        /// <returns>Cost of product (BYN)</returns>
        public override decimal GetCost()
        {
            decimal result = (Price - discount) * QuantityOfGoods;
            return Math.Round(result, 2);
        }
    }
}

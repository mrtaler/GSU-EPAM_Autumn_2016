using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSU_EPAM_Autumn_2016.Task02
{
    public class PurchaseWithDiscountToCostAbstractPurchase : AbstractPurchase
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
        public PurchaseWithDiscountToCostAbstractPurchase()
            : base()
        {
            discount = 0;
        }
        /// <summary>
        /// Constructor with param
        /// </summary>
        /// <param name="productName">Name</param>
        /// <param name="price">price (BYN)</param>
        /// <param name="quantityOfcomodity">quantity</param>
        /// <param name="discount">discount (BYN)</param>
        public PurchaseWithDiscountToCostAbstractPurchase(string productName, decimal price, int quantityOfcomodity, decimal discount)
            : base(new Commodity(productName, price), quantityOfcomodity)
        {
            this.discount = discount;
        }
        /// <summary>
        /// Method for calc product cost
        /// </summary>
        /// <returns>Cost of product (BYN)</returns>
        public override decimal GetCost()
        {

            decimal result = (base.Comodity.Price - discount) * base.QuantityOfcomodity;
            return Math.Round(result, 2);
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
    }
}

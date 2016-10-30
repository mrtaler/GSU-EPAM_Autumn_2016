using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSU_EPAM_Autumn_2016.Task02
{
    public class PurchaseWithDiscountToCountAbstractPurchase : AbstractPurchase
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
        public const int CountToDiscount = 10;
        /// <summary>
        /// Basic constructor 
        /// </summary>
        public PurchaseWithDiscountToCountAbstractPurchase()
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
        /// <param name="discount">discount %</param>
        public PurchaseWithDiscountToCountAbstractPurchase(string productName, decimal price, int quantityOfcomodity, decimal discount)
            : base(new Commodity(productName, price), quantityOfcomodity)
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
            decimal result;

            if (base.QuantityOfcomodity >= CountToDiscount)
            {
                result = base.QuantityOfcomodity * base.Comodity.Price * (1 - discount / 100);
            }
            else result = base.Comodity.Price * base.QuantityOfcomodity;

            return Math.Round(result, 2);
        }

    }
}

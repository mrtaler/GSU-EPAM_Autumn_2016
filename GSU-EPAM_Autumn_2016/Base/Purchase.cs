using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Base
{
    /// <summary>
    /// Base Class for Goods Purchase
    /// </summary>
    public class Purchase
    {
        private string productName;
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
            }
        }

        private int quantityOfGoods;
        public int QuantityOfGoods
        {
            get
            {
                return quantityOfGoods;
            }
            set
            {
                quantityOfGoods = value;
            }
        }

        private decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
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
        /// Basic constructor
        /// </summary>
        public Purchase()
        {
            productName = string.Empty;
            quantityOfGoods = 0;
            price = 0;
        }
        /// <summary>
        /// Constructor with param
        /// </summary>
        /// <param name="productName">Name of product</param>
        /// <param name="quantityOfGoods">Quanity product</param>
        /// <param name="price">Price product (BYN)</param>
        public Purchase(string productName, int quantityOfGoods, decimal price)
        {
            this.productName = productName;
            this.quantityOfGoods = quantityOfGoods;
            this.price = price;
        }
        /// <summary>
        /// Method for calc product cost
        /// </summary>
        /// <returns>Cost of product (BYN)</returns>
        public virtual decimal GetCost()
        {
            decimal result = quantityOfGoods * price;
            return Math.Round(result, 2);
        }
        /// <summary>
        /// Overrided method to show in CSV
        /// </summary>
        /// <returns>CSV with separator ";"</returns>
        public override string ToString()
        {
            return (
                productName + ';' + '\t' + '\t' +
                quantityOfGoods + ';' + '\t' +
                price + ';' + '\t' +
                CostOfGoods
                );
        }
        /// <summary>
        /// Overrided method to find equals 
        /// </summary>
        /// <param name="other">copy of PurchaseOfGoods for comparison </param>
        /// <returns>true if productName and price is Equals</returns>
        public virtual bool Equals(Purchase other)
        {
            return (this.productName == other.productName && this.price == other.price);
        }
    }
}
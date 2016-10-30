using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSU_EPAM_Autumn_2016.Task02
{
    public class Commodity
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

        /// <summary>
        /// Basic constructor
        /// </summary>
        public Commodity()
        {
            productName = string.Empty;
            price = 0;
        }
        /// <summary>
        /// Constructor with param
        /// </summary>
        /// <param name="productName">Name of product</param>
        /// <param name="price">Price product (BYN)</param>
        public Commodity(string productName, decimal price)
        {
            this.productName = productName;
            this.price = price;
        }
        /// <summary>
        /// Overrided method to show in CSV
        /// </summary>
        /// <returns>CSV with separator ";"</returns>
        public override string ToString()
        {
            return (
                productName + ';' + '\t' +
                price
                );
        }
    }
}

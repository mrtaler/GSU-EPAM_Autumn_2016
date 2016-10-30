using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSU_EPAM_Autumn_2016.Task02
{
    class PurchaseWithTransportationCostsAbstractPurchase : AbstractPurchase
    {
        private decimal transportationCosts;
        public decimal TransportationCosts
        {
            get
            {
                return transportationCosts;
            }
            set
            {
                transportationCosts = value;
            }
        }
        /// <summary>
        /// Basic constructor 
        /// </summary>
        public PurchaseWithTransportationCostsAbstractPurchase()
            : base()
        {
            transportationCosts = 0;
        }
        /// <summary>
        /// Constructor with param
        /// </summary>
        /// <param name="productName">Name</param>
        /// <param name="price">price (BYN)</param>
        /// <param name="quantityOfcomodity">quantity</param>
        /// <param name="transportationCosts">Transportation Costs (BYN)</param>
        public PurchaseWithTransportationCostsAbstractPurchase(string productName, decimal price, int quantityOfcomodity, decimal transportationCosts)
            : base(new Commodity(productName, price), quantityOfcomodity)
        {
            this.transportationCosts = transportationCosts;
        }
        /// <summary>
        /// Method for calc product cost
        /// </summary>
        /// <returns>Cost of product (BYN)</returns>
        public override decimal GetCost()
        {
            decimal result = (base.Comodity.Price * base.QuantityOfcomodity) + transportationCosts;
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
                + transportationCosts
                );
        }

    }
}

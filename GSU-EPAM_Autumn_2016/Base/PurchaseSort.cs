using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Base
{
    class PurchaseSort : IComparer<Purchase>
    {
        public int Compare(Purchase x, Purchase y)
        {
            int result = 0;
            int nameCompare = String.Compare(x.ProductName, y.ProductName);
            if (nameCompare != 0)
            {
                result = nameCompare;
            }
            else
            {
                if (x.GetType() == y.GetType())
                {
                    result = (y.GetCost().CompareTo(x.GetCost()) * (-1));
                }

                else if (x.GetType() == typeof(Purchase))
                {
                    result = -1;
                }
                else/* if (y.GetType() == typeof(Purchase) && x.GetType() == typeof(PricePurchase))*/
                {
                    result = 1;
                }

            }
            string ss = @"([""].*[""])";
            return result;
        }
    }
}

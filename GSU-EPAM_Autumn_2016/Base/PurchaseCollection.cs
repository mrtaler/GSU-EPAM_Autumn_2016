using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Base
{
    class PurchaseCollection
    {
        private List<Purchase> purchaseList;

        public List<Purchase> PurchaseList
        {
            get { return new List<Purchase>(purchaseList); }
        }

        public PurchaseCollection()
        {
            purchaseList = null;
        }

        public PurchaseCollection(string csvFileName)
        {
            #region find file in working directory
            string substr = "bin\\debug";
            string filePatch = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                .ToLower().Replace(substr, "")
                               + "\\" + csvFileName + ".csv";
            #endregion

            try
            {
                using (StreamReader ins = new StreamReader(filePatch))
                {
                    purchaseList = new List<Purchase>();
                    string fileDataPerString = null;
                    while ((fileDataPerString = ins.ReadLine()) != null)
                    {
                        try
                        {
                            purchaseList.Add(createPurchase(fileDataPerString));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.TargetSite);
                            Console.WriteLine(ex.InnerException);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("FileNotFoundException :" + ex.TargetSite);
                purchaseList = new List<Purchase>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringFromCsvFile"></param>
        /// <returns></returns>
        /// <exception cref="e">dsf</exception>
        private Purchase createPurchase(string stringFromCsvFile)
        {
            try
            {
                string[] stringDivBySeparator = stringFromCsvFile.Split(';');





                if (stringDivBySeparator.Length == 4)
                {
                    return new PricePurchase(
                        productName: stringDivBySeparator[0],
                        price: Convert.ToDecimal(stringDivBySeparator[1]),
                        quantityOfGoods: Convert.ToInt32(stringDivBySeparator[2]),
                        discount: Convert.ToDecimal(stringDivBySeparator[3]));
                }
                else if (stringDivBySeparator.Length == 3)
                {
                    return new Purchase(
                        productName: stringDivBySeparator[0],
                        price: Convert.ToDecimal(stringDivBySeparator[1]),
                        quantityOfGoods: Convert.ToInt32(stringDivBySeparator[2])
                        );
                }
                else
                {
                    throw new ArgumentOutOfRangeException(stringDivBySeparator.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}

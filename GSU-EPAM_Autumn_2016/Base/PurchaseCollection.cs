using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Base
{
    class PurchaseCollection
    {
        private List<Purchase> purchaseList;

        public List<Purchase> PurchaseList
        {
            get
            {
                return new List<Purchase>(purchaseList);
                /* return purchaseList;*/
            }
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public PurchaseCollection()
        {
            purchaseList = null;
        }
        /// <summary>
        /// Constructor for create collection from CSV file
        /// </summary>
        /// <param name="csvFileName">File name without extension</param>
        public PurchaseCollection(string csvFileName)
        {
            #region Find file in working directory
            string filePatch = csvFileName + ".csv";
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
                        catch (CsvStringException ex)
                        {
                            Console.WriteLine(ex.Message);
                            if (ex.InnerException != null)
                            {
                                Console.WriteLine(ex.InnerException.Message);
                                Console.WriteLine(ex.InnerException.TargetSite);
                            }
                            Console.WriteLine();
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
        /// Method for insert Purchase in List (if index is not valid insert in end)
        /// </summary>
        /// <param name="indexInsert">Index position</param>
        /// <param name="purchaseInsert">Inserted purchase</param>
        public void Insert(int indexInsert, Purchase purchaseInsert)
        {
            try
            {
                purchaseList.Insert(indexInsert, purchaseInsert);
            }
            catch (ArgumentOutOfRangeException)
            {
                purchaseList.Add(purchaseInsert);
            }
        }
        /// <summary>
        /// Method for delete Purchase from collection by position
        /// </summary>
        /// <param name="indexDelete">Position purchase for delete</param>
        /// <returns>Purchse position if delete success, -1 if not success </returns>
        public int Delete(int indexDelete)
        {
            try
            {
                purchaseList.RemoveAt(indexDelete);
                return indexDelete;
            }
            catch (ArgumentOutOfRangeException)
            {
                return -1;
            }
        }
        /// <summary>
        /// Method for calc total cost in purchse collection
        /// </summary>
        /// <returns>Total cost in BYN</returns>
        public decimal TotalCost()
        {
            return (
                purchaseList.Sum(p => p.GetCost())
                );
        }
        /// <summary>
        /// Method for print purchse collection
        /// </summary>
        /// <param name="message">Message in top before table</param>
        public void PrintCollection(string message = "")
        {
            Console.WriteLine(message);
            Console.WriteLine("{0,-10} {1, -10} {2,-10} {3,-10} {4,-10}", "Name", "Price", "Count", "Cost", "Discount");
            foreach (var itemPurchaseList in purchaseList)
            {
                Console.WriteLine(itemPurchaseList);
            }
            Console.WriteLine("{0,-10} {1,24}", "Total cost is:", TotalCost());
            Console.WriteLine();
        }
        /// <summary>
        /// Method for sort list
        /// </summary>
        /// <param name="cmp">Parame for sort</param>
        public void Sort(IComparer<Purchase> cmp)
        {
            purchaseList.Sort(cmp);
        }
        /// <summary>
        /// Method for create Purchase from CSV String
        /// </summary>
        /// <param name="stringFromCsvFile">String with separator ;</param>
        /// <returns>Purchase with discount, or not discount</returns>
        /// <exception cref="CsvStringException">CSV string ex</exception>
        private Purchase createPurchase(string stringFromCsvFile)
        {
            string[] stringDivBySeparator = stringFromCsvFile.Split(';');
            // string patternFindTrueString = @"([a-zA-z]+[;]\d*[;]\d*[;]\d*)|([a-zA-z]+[;]\d*[;]\d*)";

            //if (!Regex.IsMatch(stringFromCsvFile, patternFindTrueString))
            if (stringDivBySeparator.Length > 4 || stringDivBySeparator.Length < 3) //Check for lengh string
            {
                throw new CsvStringException("string :--" + stringFromCsvFile + "-- is not valid");
            }

            if (stringDivBySeparator[0] == "") //Check for not null name of Purchase
            {
                throw new CsvStringException("string :--" + stringFromCsvFile + "-- name of Purchase is null");
            }

            try
            {
                if (Regex.IsMatch(stringFromCsvFile, @"([a-zA-z]+[;]\d*[;]\d*[;]\d*)"))//Select data with discount
                {
                    if (Convert.ToDecimal(stringDivBySeparator[3]) > Convert.ToDecimal(stringDivBySeparator[1])) //Check data for valid discount value
                    {
                        throw new CsvStringException("in string :--" + stringFromCsvFile + "-- discount more then cost");
                    }
                    else
                    {
                        return new PricePurchase(
                            productName: stringDivBySeparator[0],
                            price: Convert.ToDecimal(stringDivBySeparator[1]),
                            quantityOfGoods: Convert.ToInt32(stringDivBySeparator[2]),
                            discount: Convert.ToDecimal(stringDivBySeparator[3])
                            );
                    }
                }
                else //Select data without discount
                {
                    return new Purchase(
                        productName: stringDivBySeparator[0],
                        price: Convert.ToDecimal(stringDivBySeparator[1]),
                        quantityOfGoods: Convert.ToInt32(stringDivBySeparator[2])
                   );
                }
            }
            catch (FormatException ex)
            {
                throw new CsvStringException("string :--" + stringFromCsvFile + "-- decimal number have is not valid format", ex);
            }
        }
        /// <summary>
        /// CsvStringException
        /// </summary>
        [Serializable]
        public class CsvStringException : ApplicationException
        {
            /// <summary>
            /// Default constructor
            /// </summary>
            public CsvStringException() { }
            /// <summary>
            /// Constructor sets the value of the inherited properties of the Message;
            /// </summary>
            /// <param name="message">Message</param>
            public CsvStringException(string message) : base(message) { }
            /// <summary>
            /// Constructor for the treatment of "internal exclusion";
            /// </summary>
            /// <param name="message">message</param>
            /// <param name="ex">innerEx</param>
            public CsvStringException(string message, Exception exception) : base(message, exception) { }
            /// <summary>
            /// Constructor to handle serialization type
            /// </summary>
            /// <param name="info"></param>
            /// <param name="contex"></param>
            protected CsvStringException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext contex)
                : base(info, contex) { }
        }
    }
}
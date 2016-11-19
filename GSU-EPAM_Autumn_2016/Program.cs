using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Find file in working directory
            string filePatch = args[0] + ".csv";
        }
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GSU_EPAM_Autumn_2016
{
    /// <summary>
    /// Class for LineSegment
    /// </summary>
    public class LineSegmentList
    {
        private List<LenNum> lenNumList;
        /// <summary>
        /// LenNumCollections
        /// </summary>
        public List<LenNum> LenNumList
        {
            get
            {
                return lenNumList;
            }
            set
            {
                lenNumList = value;
            }
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public LineSegmentList()
        {
            lenNumList = null;
        }
        /// <summary>
        /// Constructor with param(file name)
        /// </summary>
        /// <param name="fileName">File name without .txt</param>
        public LineSegmentList(string fileName)
        {
            #region find file in working directory
            string substr = "bin\\debug";
            string filePatch = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                 .ToLower().Replace(substr, "")
                 + "\\" + fileName + ".txt";
            #endregion

            try // open file 
            {
                using (StreamReader ins = new StreamReader(filePatch))
                {
                    string fileDataPerString;
                    lenNumList = new List<LenNum>();
                    while ((fileDataPerString = ins.ReadLine()) != null) //read file by string
                    {
                        try
                        {
                            LineSegment lnSeg = new LineSegment(fileDataPerString);//Calc lineSegment len
                            LenNum lenNum = new LenNum(
                                len: lnSeg.LengthLineSegment,
                                num: 1
                                ); //make new LenNum 

                            int findLenInColl = lenNumList.BinarySearch(lenNum, new LenNumSort()); //find new LenNum in list
                            if (findLenInColl >= 0) //if finded -> Num add 1
                            {
                                lenNumList[findLenInColl].IncreaseNum();
                            }
                            else //if not find add in collection new LenNum
                            {
                                lenNumList.Insert(~findLenInColl, lenNum);
                            }
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
            }
        }
    }
}

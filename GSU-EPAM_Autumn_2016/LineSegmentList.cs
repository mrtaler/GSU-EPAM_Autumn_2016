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

        private List<LineSegment> lineSegmentListColl;
        /// <summary>
        /// Line segment collections from file
        /// </summary>
        public List<LineSegment> LineSegmentListColl
        {
            get
            {
                return new List<LineSegment>(lineSegmentListColl);
            }
        }
        /// <summary>
        /// LenNumCollections
        /// </summary>
        public List<LenNum> LenNumList
        {
            get
            {
                return makeLenNumList();
            }
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public LineSegmentList()
        {
            lineSegmentListColl = null;
        }
        /// <summary>
        /// Constructor with param(file name)
        /// </summary>
        /// <param name="fileName">File name without .txt</param>
        public LineSegmentList(string fileName)
        {
            #region Find file in working directory
            string filePatch = fileName + ".txt";
            #endregion
            try // open file 
            {
                using (StreamReader ins = new StreamReader(filePatch))
                {
                    string fileDataPerString;
                    lineSegmentListColl = new List<LineSegment>();
                    while ((fileDataPerString = ins.ReadLine()) != null) //read file by string
                    {
                        try
                        {
                            lineSegmentListColl.Add(new LineSegment(fileDataPerString));
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
        /// <summary>
        /// Method for calc equals length 
        /// </summary>
        /// <returns>Collection (len;num)</returns>
        private List<LenNum> makeLenNumList()
        {
            List<LineSegment> distinctLengthLineSegment = lineSegmentListColl.Distinct(new LineSegmentEqualy()).ToList(); //Find equals lenght

            distinctLengthLineSegment.Sort(new LineSegmentSort()); //Sort by Comparer

            List<LenNum> lenNumList = new List<LenNum>();


            foreach (var item in distinctLengthLineSegment)
            {
                lenNumList.Add(new LenNum(
                   len: item.LengthLineSegment,
                   num: lineSegmentListColl.Count(p => p.LengthLineSegment == item.LengthLineSegment) //count not equals len
                    ));
            }
            return lenNumList;
        }
    }
}

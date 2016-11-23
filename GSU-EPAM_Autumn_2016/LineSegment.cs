using System;
using System.Text.RegularExpressions;

namespace GSU_EPAM_Autumn_2016
{
    /// <summary>
    /// Class description linesegment
    /// </summary>
    public class LineSegment
    {
        private double x1, x2, y1, y2;
        /// <summary>
        /// Line segment length 
        /// </summary>
        public double LengthLineSegment
        {
            get
            {
                return getLengthLineSegment();
            }
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public LineSegment()
        {
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
        }
        /// <summary>
        /// Constructor take readed full line from file
        /// </summary>
        /// <param name="inputLine"></param>
        public LineSegment(string inputLine)
        {
            var inputMatch = Regex.Matches(inputLine, @"[(].*?[)]"); //Find all data in ( ) ( )
            bool isOne = true;//flag for x1,y1 data
            foreach (var item in inputMatch)
            {
                string[] data = item.ToString().Split(';');
                try
                {
                    if (isOne)
                    {

                        x1 = double.Parse(Regex.Match(data[0], @"(?<=[(])\s*([-+]?((\d+,\d*|,\d+)([eE][-+]?\d+)?|\d+[eE][-+]?\d+)|[-+]?\d+)\s*").ToString());
                        y1 = double.Parse(Regex.Match(data[1], @"\s*([-+]?((\d+,\d*|,\d+)([eE][-+]?\d+)?|\d+[eE][-+]?\d+)|[-+]?\d+)\s*(?=[)])").ToString());
                    }
                    else
                    {
                        x2 = double.Parse(Regex.Match(data[0], @"(?<=[(])\s*([-+]?((\d+,\d*|,\d+)([eE][-+]?\d+)?|\d+[eE][-+]?\d+)|[-+]?\d+)\s*").ToString());
                        y2 = double.Parse(Regex.Match(data[1], @"\s*([-+]?((\d+,\d*|,\d+)([eE][-+]?\d+)?|\d+[eE][-+]?\d+)|[-+]?\d+)\s*(?=[)])").ToString());
                    }
                    isOne = false;
                }
                catch (ArgumentException ex)
                {
                    throw new CsvStringException("argumetn ex", ex);
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw new CsvStringException("index in array ex", ex);
                }
            }
        }
        /// <summary>
        /// Method for calc Length LineSegment
        /// </summary>
        /// <returns>Length</returns>
        private double getLengthLineSegment()
        {
            double result = Math.Sqrt(
            Math.Pow((x1 - x2), 2)
            +
            Math.Pow((y1 - y2), 2));

            return Math.Round(result, MidpointRounding.AwayFromZero);
        }
    }

    /// <summary>
    /// Custom Exception
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

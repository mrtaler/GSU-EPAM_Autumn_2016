namespace GSU_EPAM_Autumn_2016
{
    /// <summary>
    /// Class for output data
    /// </summary>
    public class LenNum
    {
        public double Len;
        public int Num;
        /// <summary>
        /// Default constructor
        /// </summary>
        public LenNum()
        {
            Len = 0;
            Num = 0;
        }
        /// <summary>
        /// constructor with param
        /// </summary>
        /// <param name="len">Len</param>
        /// <param name="num">count equals len</param>
        public LenNum(double len, int num)
        {
            Len = len;
            Num = num;
        }
        /// <summary>
        /// Overrided method ToString()
        /// </summary>
        /// <returns>Class property in string</returns>
        public override string ToString()
        {
            return (
                Len +
                ";" +
                Num);
        }
    }
}

using System;

namespace GSU_EPAM_Autumn_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            LineSegmentList lineLenList = new LineSegmentList("in");


            //Shows the number of equal length   
            foreach (var item in lineLenList.LenNumList)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}

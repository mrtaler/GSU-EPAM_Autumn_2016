using GSU_EPAM_Autumn_2016.Task1;
using GSU_EPAM_Autumn_2016.Task2;
using GSU_EPAM_Autumn_2016.Task3;
using System;
namespace GSU_EPAM_Autumn_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            Console.WriteLine("*******************Task 01*******************");
            new Task01();
            #endregion

            #region Task 2

            Console.WriteLine("*******************Task 02*******************");
            new Task02();
            #endregion

            #region Task 3
            Console.WriteLine("*******************Task 03*******************");
            new Task03();
            #endregion

            Console.ReadKey();
        }
    }
}

using System;
using GSU_EPAM_Autumn_2016.Task01;
using GSU_EPAM_Autumn_2016.Task02;
using System.IO;
using GSU_EPAM_Autumn_2016.Task03;

namespace GSU_EPAM_Autumn_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************Task 01*******************");
            new Task1();
            Console.WriteLine("*******************Task 02*******************");
            new Task2();
            Console.WriteLine("*******************Task 03*******************");
            new Task3();
            Console.WriteLine("*********************end*********************");
            Console.ReadKey();
        }
    }
}

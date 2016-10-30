using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Task2
{
  public  class Task02
    {
      public Task02()
      {
            //-----------------------1-------------------------------
            //new Homogeneous Object of steel (steel is default matter)
            Console.WriteLine("-----------------------1-------------------------------");
            HomogeneousObject Wire =new HomogeneousObject("Steel Wire",0.03);
            //-----------------------2-------------------------------
            //show in console with overrided method "String()"
            Console.WriteLine("-----------------------2-------------------------------");
            Console.WriteLine(Wire.ToString());
            //-----------------------3-------------------------------
            //Change matter to copper and show new mass
            Console.WriteLine("-----------------------3-------------------------------");
            Wire.Matter=new PhElement("Сopper", 8500);
            Console.WriteLine("new mass with copper material is: "+Wire.MassOfObject.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Task2
{
    /// <summary>
    /// class for Physical element 
    /// </summary>
   public class PhElement
    {
        #region Name
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                }
            }
        }
        #endregion
        #region Density
        private double density;
        public double Density
        {
            get
            {
                return density;
            }
            set
            {
                if (density!=value)
                {
                    density = value;
                }
            }
        }
        #endregion
        /// <summary>
        /// Default constructor for Steel with density 7850
        /// </summary>
        public PhElement()
        {
            name = "Stell";
            density = 7850.0;
        }
        /// <summary>
        /// Constructor with paremetr
        /// </summary>
        /// <param name="Name">Name of Matter</param>
        /// <param name="Density">Density of Matter</param>
        public PhElement(string Name, double Density)
        {
            this.Name = Name;
            this.Density = Density;
        }
        /// <summary>
        /// Overrided method to show in CSV
        /// </summary>
        /// <returns>CSV with separator ";"</returns>
        public override string ToString()
        {
            return (name + ";" + "\t" + density.ToString());
        }
    }
}

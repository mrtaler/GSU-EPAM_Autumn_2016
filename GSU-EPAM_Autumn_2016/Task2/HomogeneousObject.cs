using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Task2
{
    /// <summary>
    /// class of Homogeneous Object
    /// </summary>
    public class HomogeneousObject
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
        #region Matter
        private PhElement matter;
        public PhElement Matter
        {
            get
            {
                return matter;
            }
            set
            {
                if (matter != value)
                {
                    matter = value;
                }
            }
        }
        #endregion
        #region Volume
        private double volume;
        public double Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (volume != value)
                {
                    volume = value;
                }
            }
        }
        #endregion
        public double MassOfObject
        {
            get
            {
                return GetMass();
            }
        }
        /// <summary>
        /// default constructor 
        /// </summary>
        public HomogeneousObject()
        {
            this.Name = "wire";
            this.Matter = new PhElement();
            this.Volume = 2.35;
        }
        /// <summary>
        /// constructor with default matter(is steal)
        /// </summary>
        /// <param name="NameObject">Name of Object</param>
        /// <param name="Volume">Volume of Object</param>
        public HomogeneousObject(string NameObject,double Volume)
        {
            this.Name = NameObject;
            this.Volume = Volume;
            this.Matter = new PhElement();
        }
        /// <summary>
        /// constructor with all param
        /// </summary>
        /// <param name="NameObject">Name of Object</param>
        /// <param name="Volume">Volume of Object</param>
        /// <param name="NameMatter">Name of Matter</param>
        /// <param name="DensityMatter">Density of Matter</param>
        public HomogeneousObject(string NameObject,double Volume,string NameMatter,double DensityMatter)
        {
            this.Name = NameObject;
            this.Volume = Volume;
            this.Matter = new PhElement(NameMatter, DensityMatter);
        }
        /// <summary>
        /// Method to calc mass od object
        /// </summary>
        /// <returns>mass of object</returns>
        public double GetMass()
        {
            return (matter.Density * volume);
        }
        /// <summary>
        /// overrided method ToString to show in CSV format
        /// </summary>
        /// <returns>string in CSV with separator ";"</returns>
        public override string ToString()
        {
            return (
                name + ";" + "\t" +
                matter.ToString() + ";" + "\t" +
                volume + ";" + "\t" +
               MassOfObject);
        }
    }
}

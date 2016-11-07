using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016.Task02
{
    public abstract class UniversalChange
    {
        protected string inputData;
        protected string outputData;

        protected UniversalChange(string inputData, string outputData)
        {
            this.inputData = inputData;
            this.outputData = outputData;
        }
        public void ReplaceAndSave(string[] lines, string pattern)
        {
            using (StreamWriter st = new StreamWriter(this.inputData))
            {
                foreach (var str in lines)
                {
                    string tmp = Regex.Replace(str, pattern, Changer);
                    st.WriteLine(tmp);
                }
                st.Close();
            }
        }
        protected abstract string Changer(Match match);
    }
}
//http://www.cyberforum.ru/csharp-beginners/thread1300935.html
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016
{
    class LenNumSort : IComparer<LenNum>
    {
        public int Compare(LenNum x, LenNum y)
        {
            return x.Len.CompareTo(y.Len);
        }
    }
}

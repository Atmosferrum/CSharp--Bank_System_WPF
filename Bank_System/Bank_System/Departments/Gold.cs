﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    class Gold<T> : Department
        where T : Royal
    {
        public Gold(string Name)
               : base(Name)
        {

        }
    }
}

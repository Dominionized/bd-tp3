﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoratApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            TutoringContext ctx = new TutoringContext();
            TutoringApplication app = new TutoringApplication(ctx);
        }
    }
}

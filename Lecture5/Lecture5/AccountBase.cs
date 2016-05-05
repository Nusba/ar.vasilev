﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture5
{
   public class AccountBase
    {
        private int id;
        private string owner;
        private readonly double Sum;
        private bool isClose;

        protected AccountBase(int id, string owner, double sum, bool isClose)
        {
            this.id = id;
            this.owner = owner;
            this.Sum = sum;
        }
    }
}
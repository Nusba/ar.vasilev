﻿using System;
using System.Collections.Generic;

namespace Lecture11
{
    public static class IntExtensions
    {
        public static void PrintNumbers(this List<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture._4
{
    using System.CodeDom;

    internal class Telephone
    {
        private string Code;
        private string Number;

        public Telephone(string code, string number)
        {
            Code = code;
            Number = number;
        }

        public string Compare()
        {
            if (Code != null || Code != String.Empty)
            {
                return Number;
            }
            return "(" + Code + ")" + Number;
        }

    }
}

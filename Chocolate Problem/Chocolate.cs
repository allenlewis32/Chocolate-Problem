using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate_Problem
{
    internal class Chocolate
    {
        internal Color Color
        {
            get; set;
        }
        internal Chocolate(Color color)
        {
            this.Color = color;
        }
    }
}

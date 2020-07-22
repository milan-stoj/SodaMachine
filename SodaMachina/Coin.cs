using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachina
{
    abstract class Coin
    {
        protected string name;
        protected double value;

        public double Value { get => value; }
        public string Name { get => name; }

    }
}

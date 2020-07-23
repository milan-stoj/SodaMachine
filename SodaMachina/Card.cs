using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachina
{
    class Card
    {
        protected double availableFunds;
        public double AvailableFunds { get => availableFunds; }

        public Card()
        {
            availableFunds = 0.01;
        }

        public void RemoveFunds(double cost)
        {
            availableFunds -= cost;
        }

    }
}

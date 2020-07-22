using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachina
{
    class Simulation
    {
        Customer customer;
        SodaMachine sodaMachine;

        public Simulation()
        {
            customer = new Customer();
            sodaMachine = new SodaMachine();
        }
    }
}

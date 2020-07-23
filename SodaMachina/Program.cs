using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachina
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(60, 55);
            Simulation sim = new Simulation();
            sim.Run();

        }
    }
}

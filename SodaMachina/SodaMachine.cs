using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachina
{
    class SodaMachine
    {
        public List<Coin> register;
        public List<Can> inventory;

        public SodaMachine()
        {
            inventory = new List<Can>();

            for (int i = 0; i < 10; i++) { inventory.Add(new Cola()); }
            for (int i = 0; i < 10; i++) { inventory.Add(new OrangeSoda()); }
            for (int i = 0; i < 10; i++) { inventory.Add(new RadBull()); }
            for (int i = 0; i < 10; i++) { inventory.Add(new RootBeer()); }

            register = new List<Coin>();
            for (int i = 0; i < 20; i++) { register.Add(new Quarter()); }
            for (int i = 0; i < 10; i++) { register.Add(new Nickel()); }
            for (int i = 0; i < 20; i++) { register.Add(new Penny()); }
            for (int i = 0; i < 50; i++) { register.Add(new Quarter()); }
        }
    }
}

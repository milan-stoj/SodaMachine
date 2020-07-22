using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachina
{
    class Wallet
    {
        List<Coin> coins;
        Card card;

        public Wallet()
        {
            coins = new List<Coin>();
            for (int i = 0; i < 12; i++) { coins.Add(new Quarter()); }
            for (int i = 0; i < 10; i++) { coins.Add(new Dime()); }
            for (int i = 0; i < 15; i++) { coins.Add(new Nickel()); }
            for (int i = 0; i < 25; i++) { coins.Add(new Penny()); }
        }
    }
}

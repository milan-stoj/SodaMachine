using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

            for (int i = 0; i < 1; i++) { inventory.Add(new Cola()); }
            for (int i = 0; i < 1; i++) { inventory.Add(new OrangeSoda()); }
            for (int i = 0; i < 1; i++) { inventory.Add(new RadBull()); }
            for (int i = 0; i < 1; i++) { inventory.Add(new RootBeer()); }

            register = new List<Coin>();
            for (int i = 0; i < 20; i++) { register.Add(new Quarter()); }
            for (int i = 0; i < 10; i++) { register.Add(new Nickel()); }
            for (int i = 0; i < 20; i++) { register.Add(new Penny()); }
            for (int i = 0; i < 50; i++) { register.Add(new Quarter()); }
        }

        public double RegisterTotal()
        {
            double total = 0;
            foreach(Coin coin in register)
            {
                total += coin.Value;
            }
            return total;
        }

        public bool CheckInventory(string sodaName)
        {
            foreach(Can can in inventory)
            {
                if (can.Name == sodaName)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Coin> ReturnChange(double changeDue)
        {
            double changeRemaining = changeDue * 100;
            List<Coin> changeReturned = new List<Coin>();

            while(changeRemaining != 0)
            {
                if (changeRemaining % 25 == 0 && CoinPresent("Quarter"))
                {
                    changeReturned.Add(TransferCoinOut("Quarter"));
                    changeRemaining -= 25;
                }
                else if (changeRemaining % 10 == 0 && CoinPresent("Dime"))
                {
                    changeReturned.Add(TransferCoinOut("Dime"));
                    changeRemaining -= 10;
                }
                else if (changeRemaining % 5 == 0 && CoinPresent("Nickel"))
                {
                    changeReturned.Add(TransferCoinOut("Nickel"));
                    changeRemaining -= 5;
                }
                else if (changeRemaining % 1 == 0 && CoinPresent("Penny"))
                {
                    changeReturned.Add(TransferCoinOut("Penny"));
                    changeRemaining -= 1;
                }
            }
            return changeReturned;
        }

        public double ReturnSodaPrice(string sodaName)
        {
            foreach (Can can in inventory)
            {
                if (can.Name == sodaName)
                {
                    return can.Cost;
                }
            }
            return 0.00;
        }

        public Coin TransferCoinOut(string target)
        {
            foreach (Coin coin in register)
            {
                if (coin.Name == target)
                {
                    register.Remove(coin);
                    return coin;
                }
            }
            return null;
        }

        public double TotalPassed(List<Coin> coins)
        {
            double total = 0;
            foreach (Coin coin in coins)
            {
                total += coin.Value;
            }
            return total;
        }

        public Can TransferSoda(string sodaName)
        {
            foreach (Can can in inventory)
            {
                if (can.Name == sodaName)
                {
                    inventory.Remove(can);
                    return can;
                }
            }
            return null;
        }

        public bool CoinPresent(string name)
        {
            foreach (Coin coin in register)
            {
                if (coin.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
    }


}

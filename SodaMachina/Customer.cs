using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachina
{
    class Customer
    {
        public Wallet wallet;
        public Backpack backpack;

        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
        }

        public bool CheckWallet(string target)
        {
            foreach (Coin coin in wallet.coins)
            {
                if (coin.Name == target)
                {
                    return true;
                }
            }
            return false;
        }

        public Coin TransferCoinOut(string target)
        {
            foreach (Coin coin in wallet.coins)
            {
                if (coin.Name == target)
                {
                    wallet.coins.Remove(coin);
                    return coin;
                }
            }
            return null;
        }
    }
}

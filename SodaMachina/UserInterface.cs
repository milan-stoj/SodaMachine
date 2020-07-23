using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachina
{
    static class UserInterface
    {
        
        public static void Choices()
        {
            Console.WriteLine(@"
    Input 'i'   : Get info about products.
    Input 'm'   : Insert cash/coin into the machine.
    Input 'c'   : Insert credit card into the machine.
    Input 'b'   : View contents of backpack (coming soon).
    Input 'w'   : View contents of wallet (combing soon).
");
        }

        public static void MainMenu()
        {
            Console.Clear();
            Header();
            Console.WriteLine(@"
    ╬═══════════════════════════════════════════╬
    ║  Select an item for more info, or insert  ║
    ║            cash or credit card.           ║
    ╬═══════════════════════════════════════════╬
");
        }

        public static char GetChoice()
        {
            return ValidatedChoice(Console.ReadKey(true).KeyChar);
        }

        private static char ValidatedChoice(char choice)
        {
            switch (choice)
            {
                case 'i':
                    return choice;
                case 'c':
                    return choice;
                case 'm':
                    return choice;
                case 'x':
                    return choice;
                case 'b':
                    return choice;
                case 'w':
                    return choice;
                
                default:
                    Console.Clear();
                    MainMenu();
                    Console.WriteLine("\tNot a valid choice!");
                    return GetChoice();
            }
        }

        // Overload DisplayInfo method.
        public static void DisplayInfo(List<Can> inventory) // Method for displaying can inventory.
        {
            if (inventory.Count > 0)
            {
                List<Can> distinctCans = inventory.GroupBy(n => n.Name).Select(g => g.First()).ToList();
                foreach (Can can in distinctCans)
                {
                    double subCanTotal = 0;
                    string target = can.Name;
                    List<Can> sublist = inventory.FindAll(x => x.Name.Equals(target)); // Using predicate to extract list of items matching "Name" of distinct wallet coins.
                    int count = sublist.Count();
                    foreach (Can subcan in sublist) // Iterating through each coin type in wallet to get total value of each type.
                    {
                        subCanTotal += subcan.Cost;
                    }
                    Console.WriteLine($"\t{count} × {target}: ${can.Cost}/can");
                }
            }
            else
            {
                Console.WriteLine("\tEmpty");
            }
            Console.WriteLine("\tPress any key to return.");
            Console.ReadKey();
        }

        public static void DisplayInfo(Backpack backpack) // method for displaying contents of backpack.
        {
            if (backpack.cans.Count > 0)
            {
                List<Can> distinctCans = backpack.cans.GroupBy(n => n.Name).Select(g => g.First()).ToList();
                foreach (Can can in distinctCans)
                {
                    double subCanTotal = 0;
                    string target = can.Name;
                    List<Can> sublist = backpack.cans.FindAll(x => x.Name.Equals(target)); // Using predicate to extract list of items matching "Name" of distinct wallet coins.
                    int count = sublist.Count();
                    foreach (Can subcan in sublist) // Iterating through each coin type in wallet to get total value of each type.
                    {
                        subCanTotal += subcan.Cost;
                    }
                    Console.WriteLine($"\t{count} × {target}: ${subCanTotal}");
                }
            }
            else
            {
                Console.WriteLine("\tBackpack is Empty");
            }
            Console.WriteLine("\tPress any key to return.");
            Console.ReadKey();
        }

        public static void DisplayInfo(Wallet wallet) // method for displaying contents of wallet.
        {
            if (wallet.coins.Count > 0)
            {
                List<Coin> distinctCoins = wallet.coins.GroupBy(n => n.Name).Select(g => g.First()).ToList();
                foreach (Coin coin in distinctCoins)
                {
                    double subCoinTotal = 0;
                    string target = coin.Name;
                    List<Coin> sublist = wallet.coins.FindAll(x => x.Name.Equals(target)); // Using predicate to extract list of items matching "Name" of distinct wallet coins.
                    int count = sublist.Count();
                    foreach (Coin subcoin in sublist) // Iterating through each coin type in wallet to get total value of each type.
                    {
                        subCoinTotal += subcoin.Value;
                    }
                    Console.WriteLine($"\t{count} × {target}: ${subCoinTotal}");
                }
            }
            else
            {
                Console.WriteLine("\tWallet is Empty");
            }
            Console.WriteLine("\tPress any key to return.");
            Console.ReadKey();
        }

        public static void PurchaseSoda(Card card)
        {
            
        }













        public static void Header()
        {

            Console.WriteLine(@"
     ____________________________________________
    |############################################|
    |#|                           |##############|
    |#|  ┌───┐    ┌───┐    ┌───┐  |##|````````|##|
    |#|  │___│    │___│    │___│  |##|  Coin  |##|
    |#|  │/=_│    │/=_│    │*~_│  |##|   Or   |##|
    |#|  │   │    │   │    │   │  |##|  Card  |##|
    |#|  └───┘    └───┘    └───┘  |##|________|##|
    |#|===[1]======[2]======[3]===|##############|
    |#|```````````````````````````|##############|
    |#|  ┌───┐    ┌───┐    ┌───┐  |##############|
    |#|  │___│    │___│    │___│  |#|`````````|##|
    |#|  │/=_│    │~~_│    │/=_│  |#| _______ |##|
    |#|  │   │    │   │    │   │  |#| |1|2|3| |##|
    |#|  └───┘    └───┘    └───┘  |#| |4|5|6| |##|
    |#|===[4]======[5]======[6]===|#| |7|8|9| |##|
    |#|```````````````````````````|#| ``````` |##|
    |#|  ┌───┐    ┌───┐    ┌───┐  |#|[=======]|##|
    |#|  │___│    │___│    │___│  |#|  _   _  |##|
    |#|  │/=_│    │/=_│    │/~_│  |#| ||| ( ) |##|
    |#|  │   │    │   │    │   │  |#| |||  `  |##|
    |#|  └───┘    └───┘    └───┘  |#|  ~      |##|
    |#|===[7]======[8]======[9]===|#|_________|##|
    |#|```````````````````````````|##############|
    |############################################|
    |#|||||||||||||||||||||||||||||####```````###|
    |#||||||||||||PUSH|||||||||||||####\|||||/###|
    |############################################|
    \\\\\\\\\\\\\\\\\\\\\\///////////////////////
     |________________________________|MS94|___|
");
        }

    }
}

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
    Input 'd'   : Get info on machine change.
    Input 'p'   : Purchase a soda.
    Input 'b'   : View contents of backpack.
    Input 'w'   : View contents of wallet.
    
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
            return ValidatedMenuChoice(Console.ReadKey(true).KeyChar);
        }

        private static char ValidatedMenuChoice(char choice)
        {
            switch (choice)
            {
                case 'i':
                    return choice;
                case 'c':
                    return choice;
                case 'b':
                    return choice;
                case 'w':
                    return choice;
                case 'p':
                    return choice;
                case 'd':
                    return choice;
                default:
                    Console.Clear();
                    MainMenu();
                    Choices();
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
            Console.WriteLine($"\t1 × Credit Card: ${wallet.card.AvailableFunds}");
            Console.WriteLine("\tPress any key to return.");
            Console.ReadKey();
        }

        public static void DisplayInfo(SodaMachine sodaMachine) // method for displaying contents of machine register.
        {
            if (sodaMachine.register.Count > 0)
            {
                List<Coin> distinctCoins = sodaMachine.register.GroupBy(n => n.Name).Select(g => g.First()).ToList();
                foreach (Coin coin in distinctCoins)
                {
                    double subCoinTotal = 0;
                    string target = coin.Name;
                    List<Coin> sublist = sodaMachine.register.FindAll(x => x.Name.Equals(target)); // Using predicate to extract list of items matching "Name" of distinct wallet coins.
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
                Console.WriteLine("\tRegister is Empty");
            }
            Console.WriteLine("\tPress any key to return.");
            Console.ReadKey();
        }

        public static void PaymentChoices()
        {
            Console.WriteLine(@"
    Input '1'   : Pay with Coin/Cash
    Input '2'   : Pay with Card
");
        }

        public static char GetPaymentChoice()
        {
            return ValidatePaymentChoice(Console.ReadKey(true).KeyChar);
        }
        public static char ValidatePaymentChoice(char choice)
        {
            switch (choice)
            {
                case '1':
                    return choice;
                case '2':
                    return choice;
                default:
                    Console.Clear();
                    MainMenu();
                    PaymentChoices();
                    Console.WriteLine("\tNot a valid choice!");
                    return GetPaymentChoice();
            }

        }

        public static List<Coin> Payment(Customer customer)
        {
            List<Coin> toMachine = new List<Coin>();
            double toMachineTotal = 0;
            while (true)
            {
                MainMenu();
                Console.WriteLine($"\tTotal inserted: ${toMachineTotal}");
                CoinChoices();
                string coinChoice = GetCoinChoice();
                if (customer.CheckWallet(coinChoice) == true)
                {
                    Coin transferedCoin = customer.TransferCoinOut(coinChoice);
                    toMachine.Add(transferedCoin);
                    toMachineTotal += transferedCoin.Value;
                }
                else if(customer.CheckWallet(coinChoice) == false && coinChoice != "Select Soda")
                {
                    Console.WriteLine($"Not enough {coinChoice}'s");
                    Console.ReadKey();
                }
                else if(coinChoice == "Select Soda")
                {
                    return toMachine;
                }
            }
        }

        public static double Payment(Card card)
        {
            return card.AvailableFunds;
        }

        public static void CoinChoices()
        {
            Console.WriteLine(@"
    Input '1'   : Quarter
    Input '2'   : Dime
    Input '3'   : Nickel
    Input '4'   : Penny
    Input '5'   : Select Soda
");
        }

        public static string GetCoinChoice()
        {
            return ValidateCoinChoice(Console.ReadKey(true).KeyChar);
        }
        public static string ValidateCoinChoice(char choice)
        {
            switch (choice)
            {
                case '1':
                    return "Quarter";
                case '2':
                    return "Dime";
                case '3':
                    return "Nickel";
                case '4':
                    return "Penny";
                case '5':
                    return "Select Soda";
                default:
                    Console.Clear();
                    MainMenu();
                    CoinChoices();
                    Console.WriteLine("\tNot a valid choice!");
                    return GetCoinChoice();
            }

        }

        public static void CanChoices()
        {
            Console.WriteLine(@"
    Input '1'   : Super Cola
    Input '2'   : Orange Soda
    Input '3'   : Rad Bull
    Input '4'   : Root Beer
");
        }
        
        public static string GetCanChoice()
        {
            return ValidateCanChoice(Console.ReadKey(true).KeyChar);
        }

        public static string ValidateCanChoice(char choice)
        {
            switch (choice)
            {
                case '1':
                    return "Super Cola";
                case '2':
                    return "Orange Soda";
                case '3':
                    return "Rad Bull";
                case '4':
                    return "Root Beer";
                default:
                    Console.Clear();
                    MainMenu();
                    CanChoices();
                    Console.WriteLine("\tNot a valid choice!");
                    return GetCanChoice();
            }
        }

        public static void SelectSoda(List<Coin> transferedFunds, SodaMachine sodaMachina, Customer customer)
        {
            MainMenu();
            CanChoices();
            string canChoice = GetCanChoice();
            double totalPassed = sodaMachina.TotalPassed(transferedFunds);
            double canCost = sodaMachina.ReturnSodaPrice(canChoice);
            bool canExists = sodaMachina.CheckInventory(canChoice);

            if (canExists == true)
            {
                Console.WriteLine("\tSoda is in stock!");
                if (canCost == totalPassed)
                {
                    MainMenu();
                    Console.WriteLine("\tExact Funds adequate!");
                    Can customerCan = sodaMachina.TransferSoda(canChoice);
                    customer.backpack.cans.Add(customerCan);
                    sodaMachina.TransferCoinsIn(transferedFunds);
                    
                }
                else if(canCost < totalPassed)
                {
                    if((totalPassed - canCost) > sodaMachina.RegisterTotal() || sodaMachina.ChangePresent(totalPassed - canCost) == false)
                    {
                        MainMenu();
                        Console.WriteLine($"\tFunds adequate!\n\tBut not enough change to give. Returning payment.");
                        foreach (Coin coin in transferedFunds)
                        {
                            customer.wallet.coins.Add(coin);
                        }
                    }
                    else if(totalPassed - canCost < sodaMachina.RegisterTotal())
                    {
                        MainMenu();
                        Console.WriteLine($"\tFunds adequate!\n\tDispensing soda and {totalPassed - canCost} in change");
                        Can customerCan = sodaMachina.TransferSoda(canChoice);
                        customer.backpack.cans.Add(customerCan);
                        sodaMachina.TransferCoinsIn(transferedFunds);
                        foreach (Coin coin in sodaMachina.ReturnChange(totalPassed - canCost))
                        {
                            customer.wallet.coins.Add(coin);
                        }
                    }
                }

                else if(canCost > totalPassed)
                {
                    MainMenu();
                    Console.WriteLine("\tInsufficient funds\n\tReturning Payment");
                    foreach (Coin coin in transferedFunds)
                    {
                        customer.wallet.coins.Add(coin);
                    }
                }
                
            }
            else if (canExists == false)
            {
                MainMenu();
                Console.WriteLine("\tInsufficient stock\n\tReturning Payment");
                foreach (Coin coin in transferedFunds)
                {
                    customer.wallet.coins.Add(coin);
                }
            }
        }

        public static void SelectSoda(SodaMachine sodaMachina, Customer customer)
        {
            MainMenu();
            CanChoices();
            string canChoice = GetCanChoice();
            double totalPassed = customer.wallet.card.AvailableFunds;
            double canCost = sodaMachina.ReturnSodaPrice(canChoice);
            bool canExists = sodaMachina.CheckInventory(canChoice);

            if (canExists == true)
            {
                Console.WriteLine("\tSoda is in stock!");
                if (canCost <= totalPassed)
                {
                    MainMenu();
                    Console.WriteLine("\tCredit Card Funds adequate!");
                    Can customerCan = sodaMachina.TransferSoda(canChoice);
                    customer.backpack.cans.Add(customerCan);
                    customer.wallet.card.RemoveFunds(canCost);
                }
                
                else if (canCost > totalPassed)
                {
                    MainMenu();
                    Console.WriteLine("\tInsufficient funds on card");
                }

            }
            else if (canExists == false)
            {
                MainMenu();
                Console.WriteLine("\tInsufficient stock\n\t");
            }
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

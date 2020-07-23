using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachina
{
    class Simulation
    {
        public Customer customer;
        public SodaMachine sodaMachine;

        public Simulation()
        {
            customer = new Customer();
            sodaMachine = new SodaMachine();
        }

        public void Run()
        {
            UserInterface.MainMenu();
            UserInterface.Choices();
            GetAction(UserInterface.GetChoice());
        }


        public void GetAction(char choice)
        {
            UserInterface.MainMenu();
            if (choice == 'i')
            {
                UserInterface.DisplayInfo(sodaMachine.inventory);
            }
            else if (choice == 'p') // purchase soda
            {
                UserInterface.MainMenu();
                UserInterface.PaymentChoices();
                choice = UserInterface.GetPaymentChoice();
                if(choice == '1')
                {
                    PayWithCoin();
                }
                else if (choice == '2')
                {
                    PayWithCard();
                }
            }
            else if (choice == 'b') // View Backpack
            {
                UserInterface.DisplayInfo(customer.backpack);
            }
            else if (choice == 'w') // View Wallet 
            {
                UserInterface.DisplayInfo(customer.wallet);
            }
            else if (choice == 'd') // View Register
            {
                UserInterface.DisplayInfo(sodaMachine);
            }

            Run();
        }

        public void PayWithCoin()
        {
            // Insert Coin into Soda Machine ---- UserInterface.Payment(customer.wallet.coins);
            Console.WriteLine("Paying with coin");
            // Insert Coin into Soda Machine ---- UserInterface.Payment(customer.wallet.coins);
            List<Coin> transferingToMachine = UserInterface.Payment(customer);
            UserInterface.SelectSoda(transferingToMachine, sodaMachine, customer);
            Console.ReadLine();
        }


        public void PayWithCard()
        {
            Console.WriteLine("Paying with card");
            Console.ReadLine();
            UserInterface.SelectSoda(sodaMachine, customer); // Overload select soda method for credit card
            Console.ReadLine();
        }
        



    }
}

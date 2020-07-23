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

        public void GetAction()
        {

        }

        public void GetAction(char choice)
        {
            UserInterface.MainMenu();
            if (choice == 'i')
            {
                UserInterface.DisplayInfo(sodaMachine.inventory);
            }
            else if (choice == 'm') // Insert cash/coin
            {
                Run();
            }
            else if (choice == 'b') // View Backpack
            {
                UserInterface.DisplayInfo(customer.backpack);
            }
            else if (choice == 'c') // Insert Card 
            {
                Run();
            }
            else if (choice == 'w') // View Wallet 
            {
                UserInterface.DisplayInfo(customer.wallet);
            }
            Run();
        }



    }
}

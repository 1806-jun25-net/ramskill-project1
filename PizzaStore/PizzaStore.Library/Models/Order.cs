using PizzaStore.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Models
{
    public class Order
    {


        public Order(string orderUser, string orderLocation)
        {

        }

        public string orderLocation { get; set; }
        public string orderUser { get; set; }
        

        public void CreateOrder(string userName, string location)
        {
            mainMenu();
        }

        public string mainMenu()
        {
            string menuSelect;

            Console.WriteLine($"Please select an option from the menu to contine.\n1. Order a Classic Pizza\n2. Order a custom pizza\n" +
                                $"3. View order\n4. Checkout\n5. Change user\n6. Change location\n7. Quit Application");
            menuSelect = Console.ReadLine();
            menuSelect = menuSelect.ToLower();

            switch(menuSelect)
            {
                case "1":
                    ChooseClassicPizza();
                    break;

                case "2":
                    CreateCustomPizza();
                    break;

                case "3":
                    ViewOrder();
                    break;

                case "4":
                    Checkout();
                    break;

                case "5":
                    ChangeUser();
                    break;

                case "6":
                    ChangeLocation();
                    break;

                case "7":
                    QuitApp();
                    break;

                default: 
                    



            }
                 

            return menuSelect;
        }

        public void CreateCustomPizza()
        {
            throw new NotImplementedException();
        }

        public void ChooseClassicPizza()
        { 
            throw new NotImplementedException();
        }

        public void ViewOrder()
        {
            throw new NotImplementedException();
        }

        public string ChangeUser()
        {
            throw new NotImplementedException();
        }

        public string ChangeLocation()
        {
            throw new NotImplementedException();
        }

        public void Checkout()
        {
            throw new NotImplementedException();
        }

        public void QuitApp()
        {
            throw new NotImplementedException();
        }

    }



    
}

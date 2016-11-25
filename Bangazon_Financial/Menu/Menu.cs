using System.Collections.Generic;
using Bangazon_Financial.Factories;
using Bangazon_Financial.Actions;
using System;

namespace Bangazon_Financial.Menu
{
    //Class Name: Menu
    //Author: Grant Regnier
    //Purpose of the class: This Class is where our console application will run, all actions will be executed from here, menu interactions will start and finish in this class.
    //Methods in this Class: MarkDone, MenuSystem, Start, ShowMainMenu.
    public class Menu
    {
        private struct MenuItem
        {
            public string prompt;
            public delegate void MenuAction();
            public MenuAction Action;
        };

        private ReportFactory reportFactory = new ReportFactory(); 

        private Dictionary<int, MenuItem> _MenuItems = new Dictionary<int, MenuItem>();

        private bool done = false;

        //Method Name: MarkDone
        //Purpose of the Method: this method sets the private bool to false and ends the program.
        private void MarkDone()
        {
            done = true;
        }

        //Method Name: MenuSystem
        //Purpose of the Method: This method adds MenuItems to a private dictionary of structs.
        public void MenuSystem()
        {
            _MenuItems.Add(1, new MenuItem()
            {
                prompt = "Weekly Report",
                Action = WeeklyReport.ReadInput
            });

            _MenuItems.Add(2, new MenuItem()
            {
                prompt = "Monthly Report",
                Action = MonthlyReport.ReadInput
            });

            _MenuItems.Add(3, new MenuItem()
            {
                prompt = "Quarterly Report",
                Action = QuarterlyReport.ReadInput
            });

            _MenuItems.Add(4, new MenuItem()
            {
                prompt = "Customer Revenue Report",
                Action = CustomerRevenueReport.ReadInput
            });

            _MenuItems.Add(5, new MenuItem()
            {
                prompt = "Product Revenue Report",
                Action = ProductRevenueReport.ReadInput
            });

            _MenuItems.Add(6, new MenuItem()
            {
                prompt = "Exit Application",
                Action = MarkDone
            });
        }

        //Method Name: Start
        //Purpose of the Method: This method reruns the ShowMainMenu method continuously until the private bool done is set to true.
        public void Start()
        {
            MenuSystem();
            while (!done)
            {
                ShowMainMenu();
            }
        }

        //Method Name: ShowMainMenu
        //Purpose of the Method: This method loads the main menu and handles the user input that chooses which action to preform.
        public void ShowMainMenu()
        {
            Console.Clear();

            Console.WriteLine("==========================");
            Console.WriteLine("BANGAZON FINANCIAL REPORTS");
            Console.WriteLine("==========================");

            // Display each menu item
            foreach (KeyValuePair<int, MenuItem> item in _MenuItems)
            {
                Console.WriteLine($"\r\n{item.Key}. {item.Value.prompt}");
            }

            Console.Write("> ");

            // Read in the user's choice
            try
            {
                int choice;
                Int32.TryParse(Console.ReadLine(), out choice);

                // Based on their choice, execute the appropriate action
                MenuItem menuItem;
                _MenuItems.TryGetValue(choice, out menuItem);
                menuItem.Action();
            }
            catch
            {
                Console.WriteLine("That was not one of the options, press any key to restart");
            }
        }
    }
}



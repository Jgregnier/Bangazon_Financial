using System;
using System.Collections.Generic;
using Bangazon_Financial.Factories;
using Bangazon_Financial.Entities;
namespace Bangazon_Financial.Actions
{
    //Class Name: WeeklyReport
    //Author: Grant Regnier
    //Purpose of the class: This Class selects sales by product from the past month and displays them.
    public class WeeklyReport
    {
        //Method Name: ReadInput
        //Purpose of the Method: This method selects a list of Reports that show the products sold over the past week and displays them in the console.
        public static void ReadInput()
        {
            ReportFactory reportFactory = new ReportFactory();

            Console.WriteLine("\r\n===============");
            Console.WriteLine("REVENUE BY WEEK");
            Console.WriteLine("===============");

            List<Report> WeeklyReports = new List<Report>();
            WeeklyReports = reportFactory.GetWeeklyReports();

            if (WeeklyReports.Count == 0)
            {
                Console.WriteLine("There have been no sales this week");
            }
            else if (WeeklyReports.Count > 0)
            {
                Console.WriteLine("Product                Sales");
                foreach (Report report in WeeklyReports)
                {
                    Console.WriteLine($"{report.Name} ${report.Price}");
                }
            }

            Console.WriteLine("\r\nPress any key to return to the main menu");
            Console.ReadLine();
        }
    }
}

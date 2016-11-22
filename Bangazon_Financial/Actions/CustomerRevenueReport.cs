using System;
using System.Collections.Generic;
using Bangazon_Financial.Factories;
using Bangazon_Financial.Entities;
namespace Bangazon_Financial.Actions
{
    //Class Name: CustomerRevenueReport
    //Author: Grant Regnier
    //Purpose of the class: This Class selects a list of reports from the DB displaying total revenue from each customer.
    public class CustomerRevenueReport
    {
        //Method Name: ReadInput
        //Purpose of the Method: This method selects a list of Reports displaying the amount of revenue generated for a customer and iterates over them to write the reports to the console.
        public static void ReadInput()
        {
            RevenueReportFactory revenueReportFactory = new RevenueReportFactory();

            Console.WriteLine("\r\nRevenue By Customer\r\n");

            List<Report> CustomerRevenueReports = new List<Report>();

            CustomerRevenueReports = revenueReportFactory.GetRevenueByCustomer();

            Console.WriteLine("Customer                Revenue");

            foreach (Report report in CustomerRevenueReports)
            {
                Console.WriteLine($"{report.Name}                ${report.Price}");
            }

            Console.WriteLine("\r\nPress any key to return to the main menu");
            Console.ReadLine();
        }
    }
}
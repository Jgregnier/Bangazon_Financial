using System;
using System.Collections.Generic;
using Bangazon_Financial.Factories;
using Bangazon_Financial.Entities;
namespace Bangazon_Financial.Actions
{
    //Class Name: ProductRevenueReport
    //Author: Grant Regnier
    //Purpose of the class: This Class selects a list of reports that show revenue made per product in the history of Bangazon.
    public class ProductRevenueReport
    {
        //Method Name: ReadInput
        //Purpose of the Method: This method selects a list of Reports that show the amount of revenue made per product and iterates over them to write the reports to the console.
        public static void ReadInput()
        {
            RevenueReportFactory revenueReportFactory = new RevenueReportFactory();

            Console.WriteLine("\r\n==================");
            Console.WriteLine("REVENUE BY PRODUCT");
            Console.WriteLine("==================");

            List<Report> ProductRevenueReports = new List<Report>();

            ProductRevenueReports = revenueReportFactory.GetRevenueByProduct();

            Console.WriteLine("Product               Revenue");

            foreach (Report report in ProductRevenueReports)
            {
                Console.WriteLine($"{report.Name}                ${report.Price}");
            }

            Console.WriteLine("\r\nPress any key to return to the main menu");
            Console.ReadLine();
        }
    }
}
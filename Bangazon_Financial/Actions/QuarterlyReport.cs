﻿using System;
using System.Collections.Generic;
using Bangazon_Financial.Factories;
using Bangazon_Financial.Entities;
namespace Bangazon_Financial.Actions
{
    //Class Name: QuarterlyReport
    //Author: Grant Regnier
    //Purpose of the class: This Class selects sales by product from the past month and displays them.
    public class QuarterlyReport
    {
        //Method Name: ReadInput
        //Purpose of the Method: This method selects a list of Reports that show the products sold over the past quater and displays them in the console.
        public static void ReadInput()
        {
            ReportFactory reportFactory = new ReportFactory();

            Console.WriteLine("\r\n==================");
            Console.WriteLine("REVENUE BY QUARTER");
            Console.WriteLine("==================");

            List<Report> QuarterlyReports = new List<Report>();
            QuarterlyReports = reportFactory.GetQuarterlyReports();

            if (QuarterlyReports.Count == 0)
            {
                Console.WriteLine("There have been no sales this Quarter");
            }
            else if (QuarterlyReports.Count > 0)
            {
                Console.WriteLine("Product                Sales");
                foreach (Report report in QuarterlyReports)
                {
                    Console.WriteLine($"{report.Name} ${report.Price}");
                }
            }

            Console.WriteLine("\r\nPress any key to return to the main menu");
            Console.ReadLine();
        }
    }
}

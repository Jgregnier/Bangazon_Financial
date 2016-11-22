using System.Collections.Generic;
using Bangazon_Financial.Entities;
using Bangazon_Financial.Data;
using Microsoft.Data.Sqlite;

namespace Bangazon_Financial.Factories
{
    //Class Name: RevenurReportFactory
    //Author: Grant Regnier
    //Purpose of the class: This Class selects a list of reports that display the amount of revenue aquired from a particular customer, or the amount of revenue a particular product has made us.
    //Methods in this Class: GetWeeklyReports, GetMonthlyReports, GetQuarterlyReports.
    public class RevenueReportFactory
    {
        //Method Name: GetRevenueByCustomer
        //Purpose of the Method: This method returns a list of reports that display the amount of revenue made from each customer in the database.
        public List<Report> GetRevenueByCustomer()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();

            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Customer.FirstName || ' ' || Customer.LastName AS ""Whole Name"", SUM(Product.Price)
            FROM Customer
            JOIN 'Order' O ON Customer.CustomerId = O.CustomerId
            JOIN LineItem ON O.OrderId = LineItem.OrderId
            JOIN Product ON LineItem.ProductId = Product.ProductId
            GROUP BY ""Whole Name""";
            Conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    ReportList.Add(new Report
                    {
                        Name = reader[0].ToString(),
                        Price = reader.GetDouble(1)
                    });
                }
                reader.Close();
            });
            return ReportList;
        }

        //Method Name: GetRevenueByProduct
        //Purpose of the Method: This method returns a list of reports that display the total revenue of products sold.
        public List<Report> GetRevenueByProduct()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();

            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Product.Name, SUM(Product.Price)
            FROM Product
            JOIN LineItem ON Product.ProductId = LineItem.ProductId
            GROUP BY Product.Name";
            Conn.execute(query, (SqliteDataReader reader) =>
                {
                while (reader.Read())
                {
                    ReportList.Add(new Report
                    {
                        Name = reader[0].ToString(),
                        Price = reader.GetDouble(1)
                   });
               }
               reader.Close();
            });
            return ReportList;
        }
    }
}

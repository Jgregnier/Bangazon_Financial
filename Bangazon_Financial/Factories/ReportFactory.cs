using System.Collections.Generic;
using Bangazon_Financial.Entities;
using Bangazon_Financial.Data;
using Microsoft.Data.Sqlite;

namespace Bangazon_Financial.Factories
{
    //Class Name: ReportFactory
    //Author: Grant Regnier
    //Purpose of the class: This Class selects a list of reports detailing product sales by the past 7, 30, 90.
    //Methods in this Class: GetWeeklyReports, GetMonthlyReports, GetQuarterlyReports.
    public class ReportFactory
    {
        //Method Name: GetWeeklyReports
        //Purpose of the Method: This method returns a list of reports that display the sales of all products over the past week.
        public List<Report> GetWeeklyReports()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();
            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Product.Name, Product.Price*COUNT(LineItem.ProductId)
            FROM Product
            JOIN LineItem ON Product.ProductId = LineItem.ProductId
            JOIN 'Order' O ON LineItem.OrderId = O.OrderId
            WHERE O.DateCompleted >= datetime('now', '-7 days') AND O.DateCompleted <= datetime('now', 'localtime')
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
    
        //Method Name: ReadInput
        //Purpose of the Method: This method returns a list of reports that display the sales of all products over the past month.
        public List<Report> GetMonthlyReports()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();
            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Product.Name, Product.Price*COUNT(LineItem.ProductId)
            FROM Product
            JOIN LineItem ON Product.ProductId = LineItem.ProductId
            JOIN 'Order' O ON LineItem.OrderId = O.OrderId
            WHERE O.DateCompleted >= datetime('now', '-30 days') AND O.DateCompleted <= datetime('now', 'localtime')
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

        //Method Name: GetQuarterlyReports
        //Purpose of the Method: This method returns a list of reports that display the sales of all products over the past quarter.
        public List<Report> GetQuarterlyReports()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();
            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Product.Name, Product.Price*COUNT(LineItem.ProductId)
            FROM Product
            JOIN LineItem ON Product.ProductId = LineItem.ProductId
            JOIN 'Order' O ON LineItem.OrderId = O.OrderId
            WHERE O.DateCompleted >= datetime('now', '-90 days') AND O.DateCompleted <= datetime('now', 'localtime')
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

using System;
using Microsoft.Data.Sqlite;

namespace Bangazon_Financial.Data
{
    //Class Name: BangazonWebConnection
    //Author: Grant Regnier
    //Purpose of the class: This Class Opens a connection to our DB so we can execute sql statements and read the results.
    public class BangazonWebConnection
    {
        private string _connectionString = $"Data Source = {Environment.GetEnvironmentVariable("NTABangazonWeb_Db_Path")}";

        //Method Name: Execute
        //Purpose of the Method: This method opens a connection to the database for string querys to be executed.
        public void execute(string query, Action<SqliteDataReader> handler)
        {

            SqliteConnection dbcon = new SqliteConnection(_connectionString);

            dbcon.Open();
            SqliteCommand dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;

            using (var reader = dbcmd.ExecuteReader())
            {
                handler(reader);
            }

            // clean up
            dbcmd.Dispose();
            dbcon.Close();
        }
    }
}


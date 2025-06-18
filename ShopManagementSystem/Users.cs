using System;
using System.Data.SQLite;

namespace ShopManagementSystem
{
    public static class Users
    {
        public static string ConnectionString = "Data Source=shop.db";

        public static void Initialize()
        {
            if (!System.IO.File.Exists("shop.db"))
            {
                SQLiteConnection.CreateFile("shop.db");

                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    
                    string createUsersTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL,
                            Password TEXT NOT NULL
                        );";
                    command.CommandText = createUsersTableQuery;
                    command.ExecuteNonQuery();

                    
                    string insertUserQuery = @"
                        INSERT INTO Users (Username, Password)
                        VALUES ('admin', 'admin');";
                    command.CommandText = insertUserQuery;
                    command.ExecuteNonQuery();

                    
                    string createProductsTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Products (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Price REAL NOT NULL,
                            Quantity INTEGER NOT NULL
                        );";
                    command.CommandText = createProductsTableQuery;
                    command.ExecuteNonQuery();
                }
            }

            
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                try
                {
                    
                    var checkCommand = connection.CreateCommand();
                    checkCommand.CommandText = "SELECT IsForSale FROM Products LIMIT 1";
                    checkCommand.ExecuteReader().Close();
                }
                catch
                {
                    
                    var alterCommand = connection.CreateCommand();
                    alterCommand.CommandText = "ALTER TABLE Products ADD COLUMN IsForSale INTEGER DEFAULT 0";
                    alterCommand.ExecuteNonQuery();
                }
            }
        }
    }
}

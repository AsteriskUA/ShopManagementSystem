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

                    // Таблиця користувачів
                    string createUsersTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL,
                            Password TEXT NOT NULL
                        );";
                    command.CommandText = createUsersTableQuery;
                    command.ExecuteNonQuery();

                    // Додаємо користувача admin:admin
                    string insertUserQuery = @"
                        INSERT INTO Users (Username, Password)
                        VALUES ('admin', 'admin');";
                    command.CommandText = insertUserQuery;
                    command.ExecuteNonQuery();

                    // Таблиця товарів (без IsForSale на цьому етапі)
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

            // 🔧 Додаємо колонку IsForSale, якщо її ще нема
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                try
                {
                    // Спроба звернутись до колонки IsForSale — якщо її немає, виникне виняток
                    var checkCommand = connection.CreateCommand();
                    checkCommand.CommandText = "SELECT IsForSale FROM Products LIMIT 1";
                    checkCommand.ExecuteReader().Close();
                }
                catch
                {
                    // Якщо колонки немає — додаємо
                    var alterCommand = connection.CreateCommand();
                    alterCommand.CommandText = "ALTER TABLE Products ADD COLUMN IsForSale INTEGER DEFAULT 0";
                    alterCommand.ExecuteNonQuery();
                }
            }
        }
    }
}

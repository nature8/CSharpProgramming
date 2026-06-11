/*using System;
using Microsoft.Data.SqlClient;
using LibraryManagementSystem.Repository;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Database Connection...");
            Console.WriteLine();

            try
            {
                using (SqlConnection connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    Console.WriteLine("Database Connected Successfully!");
                    Console.WriteLine();
                    Console.WriteLine($"Server: {connection.DataSource}");
                    Console.WriteLine($"Database: {connection.Database}");
                    Console.WriteLine($"State: {connection.State}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Failed!");
                Console.WriteLine();
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}*/

using System;
using LibraryManagementSystem.Menus;
namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("====================================");
                Console.WriteLine("     LIBRARY MANAGEMENT SYSTEM");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Book Management");
                Console.WriteLine("2. Author Management");
                Console.WriteLine("3. Category Management");
                Console.WriteLine("4. Member Management");
                Console.WriteLine("5. Transaction Management");
                Console.WriteLine("0. Exit");
                Console.WriteLine("====================================");

                Console.Write("Enter Your Choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input!");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nBook Management Selected");
                        BookMenu.Show();
                        break;

                    case 2:
                        Console.WriteLine("\nAuthor Management Selected");
                        AuthorMenu.Show();
                        break;

                    case 3:
                        Console.WriteLine("\nCategory Management Selected");
                        CategoryMenu.Show();
                        break;

                    case 4:
                        Console.WriteLine("\nMember Management Selected");
                        MemberMenu.Show();
                        break;

                    case 5:
                        Console.WriteLine("\nTransaction Management Selected");
                        TransactionMenu.Show();
                        break;

                    case 0:
                        Console.WriteLine("\nThank You For Using Library Management System!");
                        break;

                    default:
                        Console.WriteLine("\nInvalid Choice!");
                        break;
                }

                if (choice != 0)
                {
                    Console.WriteLine("\nPress Any Key To Continue...");
                    Console.ReadKey();
                }

            } while (choice != 0);
        }
    }
}
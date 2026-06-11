using System;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Menus
{
    public static class TransactionMenu
    {
        public static void Show()
        {
            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("====================================");
                Console.WriteLine("      TRANSACTION MANAGEMENT");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Issue Book");
                Console.WriteLine("2. Return Book");
                Console.WriteLine("3. View All Transactions");
                Console.WriteLine("4. View Issued Books");
                Console.WriteLine("5. View Returned Books");
                Console.WriteLine("6. View Overdue Books");
                Console.WriteLine("7. Update Transaction");
                Console.WriteLine("8. Delete Transaction");
                Console.WriteLine("0. Back To Main Menu");
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
                        Console.WriteLine("\nIssue Book Selected");

                        Transaction transaction = new Transaction();

                        Console.Write("Enter Book ID: ");
                        transaction.BookID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Member ID: ");
                        transaction.MemberID = Convert.ToInt32(Console.ReadLine());

                        TransactionService service = new TransactionService();
                        service.IssueBook(transaction);

                        break;

                    case 2:
                        Console.WriteLine("\nReturn Book Selected");
                        // ReturnBook();
                        break;

                    case 3:
                        Console.WriteLine("\nView All Transactions Selected");
                        TransactionService service1 = new TransactionService();
                        List<Transaction> transactions = service1.GetAllTransactions();
                        foreach (Transaction t in transactions)
                        {
                            Console.WriteLine($"Transaction ID : {t.TransactionID}");
                            Console.WriteLine($"Book ID        : {t.BookID}");
                            Console.WriteLine($"Member ID      : {t.MemberID}");
                            Console.WriteLine($"Issue Date     : {t.IssueDate:d}");
                            Console.WriteLine($"Due Date       : {t.DueDate:d}");
                            Console.WriteLine($"Status         : {t.Status}");
                            Console.WriteLine("--------------------------------");
                        }
                        break;

                    case 4:
                        Console.WriteLine("\nView Issued Books Selected");
                        // ViewIssuedBooks();
                        break;

                    case 5:
                        Console.WriteLine("\nView Returned Books Selected");
                        // ViewReturnedBooks();
                        break;

                    case 6:
                        Console.WriteLine("\nView Overdue Books Selected");
                        // ViewOverdueBooks();
                        break;

                    case 7:
                        Console.WriteLine("\nUpdate Transaction Selected");
                        // UpdateTransaction();
                        break;

                    case 8:
                        Console.WriteLine("\nDelete Transaction Selected");
                        // DeleteTransaction();
                        break;

                    case 0:
                        Console.WriteLine("\nReturning To Main Menu...");
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
using System;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Menus
{
    public static class BookMenu
    {
        public static void Show()
        {
            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("====================================");
                Console.WriteLine("         BOOK MANAGEMENT");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("0. Back to Main Menu");
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
                    {
                        Console.WriteLine("\nAdd Book");

                        BookService bookService1 = new BookService();

                        Book book = new Book();

                        Console.Write("Enter Title: ");
                        book.Title = Console.ReadLine()!;

                        Console.Write("Enter ISBN: ");
                        book.ISBN = Console.ReadLine()!;

                        Console.Write("Enter Published Year: ");
                        book.PublishedYear = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Quantity: ");
                        book.Quantity = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Category ID: ");
                        book.CategoryID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Author ID: ");
                        book.AuthorID = Convert.ToInt32(Console.ReadLine());

                        bookService1.AddBook(book);

                        break;
                    }

                    case 2:
                        Console.WriteLine("\nView All Books Selected");
                        BookService bookService = new BookService();

                        List<Book> books = bookService.GetAllBooks();

                        foreach (Book book in books)
                        {
                            Console.WriteLine($"Book ID      : {book.BookID}");
                            Console.WriteLine($"Title        : {book.Title}");
                            Console.WriteLine($"ISBN         : {book.ISBN}");
                            Console.WriteLine($"Year         : {book.PublishedYear}");
                            Console.WriteLine($"Quantity     : {book.Quantity}");
                            Console.WriteLine($"Category ID  : {book.CategoryID}");
                            Console.WriteLine($"Author ID    : {book.AuthorID}");
                            Console.WriteLine("-----------------------------------");
                        }

                        break;

                    case 3:
                    {
                        Console.WriteLine("\nUpdate Book Selected");

                        Book book = new Book();

                        Console.Write("Enter Book ID to Update: ");
                        book.BookID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Title: ");
                        book.Title = Console.ReadLine();

                        Console.Write("Enter ISBN: ");
                        book.ISBN = Console.ReadLine();

                        Console.Write("Enter Published Year: ");
                        book.PublishedYear = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Quantity: ");
                        book.Quantity = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Category ID: ");
                        book.CategoryID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Author ID: ");
                        book.AuthorID = Convert.ToInt32(Console.ReadLine());

                        BookService newBookService1 = new BookService();
                        newBookService1.UpdateBook(book);

                        break;
                    }

                    case 4:
                        Console.WriteLine("\nDelete Book Selected");
                        Console.Write("Enter Book ID to Delete: ");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        BookService newBookService = new BookService();
                        newBookService.DeleteBook(bookId);
                        break;

                    case 0:
                        Console.WriteLine("\nReturning to Main Menu...");
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
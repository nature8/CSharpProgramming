using System;

namespace LibraryManagementSystem.Menus
{
    public static class AuthorMenu
    {
        public static void Show()
        {
            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("====================================");
                Console.WriteLine("        AUTHOR MANAGEMENT");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Author");
                Console.WriteLine("2. View All Authors");
                Console.WriteLine("3. Update Author");
                Console.WriteLine("4. Delete Author");
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
                        Console.WriteLine("\nAdd Author Selected");
                        break;

                    case 2:
                        Console.WriteLine("\nView All Authors Selected");
                        break;

                    case 3:
                        Console.WriteLine("\nUpdate Author Selected");
                        break;

                    case 4:
                        Console.WriteLine("\nDelete Author Selected");
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
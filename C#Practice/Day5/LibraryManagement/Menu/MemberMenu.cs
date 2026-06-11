using System;

namespace LibraryManagementSystem.Menus
{
    public static class MemberMenu
    {
        public static void Show()
        {
            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("====================================");
                Console.WriteLine("        MEMBER MANAGEMENT");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. View All Members");
                Console.WriteLine("3. Update Member");
                Console.WriteLine("4. Delete Member");
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
                        Console.WriteLine("\nAdd Member Selected");
                        break;

                    case 2:
                        Console.WriteLine("\nView All Members Selected");
                        break;

                    case 3:
                        Console.WriteLine("\nUpdate Member Selected");
                        break;

                    case 4:
                        Console.WriteLine("\nDelete Member Selected");
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
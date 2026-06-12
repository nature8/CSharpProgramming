using System;

namespace LibraryManagementSystem.Menus
{
    public static class CategoryMenu
    {
        public static void Show()
        {
            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("====================================");
                Console.WriteLine("       CATEGORY MANAGEMENT");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. View All Categories");
                Console.WriteLine("3. Update Category");
                Console.WriteLine("4. Delete Category");
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
                        Console.WriteLine("\nAdd Category Selected");
                        // AddCategory();
                        break;

                    case 2:
                        Console.WriteLine("\nView All Categories Selected");
                        // ViewAllCategories();
                        break;

                    case 3:
                        Console.WriteLine("\nUpdate Category Selected");
                        // UpdateCategory();
                        break;

                    case 4:
                        Console.WriteLine("\nDelete Category Selected");
                        // DeleteCategory();
                        break;

                    case 0:
                        Console.WriteLine("\nReturning To Main Menu...");
                        // Back To Main Menu
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
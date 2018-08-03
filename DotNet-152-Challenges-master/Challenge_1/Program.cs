using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuRepository Repository = new MenuRepository();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Commands:\nAdd: 'add'\nList: 'list'\nDelete: 'delete'");
                string Command = Console.ReadLine().ToLower();
                if (Command == "add")
                {
                    MenuItem newItem = NewMenuItem();
                    Repository.AddItem(newItem);
                }
                else if (Command == "list")
                {
                    Console.Clear();
                    foreach(MenuItem Item in Repository.GetMenuItems())
                    {
                        Console.WriteLine($"[{Item.OrderNumber}]: {Item.OrderName}, \n    {Item.Description}, \n    {Item.Ingredients}, \n    ${Item.Price}");
                    }
                    Console.WriteLine("Press Enter to continue.");
                    Console.Read();
                }
                else if (Command == "delete")
                {
                    Console.Clear();
                    Console.WriteLine("What Order Number would you like to remove?");
                    int OrderNumber = Int32.Parse(Console.ReadLine());
                    Repository.RemoveItem(OrderNumber);
                    Console.WriteLine("Item Removed. Press Enter to continue.");
                    Console.Read();
                }
            }
        }

        static MenuItem NewMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Order Number:");
            int OrderNumber = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Order Name:");
            string OrderName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Order Description:");
            string Description = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Ingredients:");
            string Ingredients = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Price:");
            decimal Price = Decimal.Parse(Console.ReadLine());
            Console.Clear();

            
            Console.WriteLine("Menu Item Created. Press Enter to Continue.");
            Console.Read();
            return new MenuItem(OrderNumber, OrderName, Description, Ingredients, Price);
        }
    }
}

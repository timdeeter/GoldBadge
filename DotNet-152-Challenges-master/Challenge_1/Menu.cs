using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class MenuItem : IEquatable<MenuItem>
    {

        public MenuItem(int orderNumber, string orderName, string description, string ingredients, decimal price)
        {
            OrderNumber = orderNumber;
            OrderName = orderName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

        public int OrderNumber { get; set; }
        public string OrderName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }

        public bool Equals(MenuItem other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.OrderNumber == other.OrderNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class MenuRepository
    {
        private List<MenuItem> MenuList = new List<MenuItem>();

        public void AddItem(MenuItem toAdd)
        {
            MenuList.Add(toAdd);
        }

        public void RemoveItem(int orderNumber)
        {
            MenuItem placeHolder = new MenuItem(orderNumber, "", "", "", 0.0m);
            MenuList.Remove(placeHolder);
        }

        public List<MenuItem> GetMenuItems()
        {
            return MenuList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class Outings
    {
        public enum OutingType {
            Golf=1,
            Bowling,
            AmusementPark,
            Concert,
        }

        public Outings(int type, DateTime date, decimal costPerPerson, int headCount)
        {
            Type = (OutingType)type;
            Date = date;
            CostPerPerson = costPerPerson;
            Headcount = headCount;
            TotalCost = costPerPerson * headCount;
        }

        public Enum Type { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public int Headcount { get; set;}
        public decimal TotalCost { get; set; }
    }

    public class OutingRepository
    {
        private List<Outings> OutingsList = new List<Outings>();

        public void addOuting(Outings outing)
        {
            OutingsList.Add(outing);
        }

        public List<Outings> getOutings()
        {
            return OutingsList;
        }

        public List<Outings> getOutingsByType(int type)
        {
            List<Outings> OutingsByType = new List<Outings>();
            foreach (Outings outing in OutingsList)
            {
                if (Convert.ToInt32(outing.Type) == type)
                {
                    OutingsByType.Add(outing);
                }
            }
            return OutingsByType;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class Program
    {
        static OutingRepository outingRepository = new OutingRepository();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Komodo Outings \n" +
                    "1. Add new outing \n" +
                    "2. List all outings \n" +
                    "3. List outings by type"
                    );
                string command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        Console.Clear();
                        outingRepository.addOuting(newOuting());
                            break;
                    case "2":
                        Console.Clear();
                        decimal totalCost = 0.00m;
                        foreach (Outings outing in outingRepository.getOutings())
                        {
                            totalCost = totalCost + outing.TotalCost;
                            Console.WriteLine($"{outing.Type}, {outing.Date.ToShortDateString()}, {outing.Headcount} people totaling ${outing.TotalCost}");
                        }
                        Console.WriteLine($"The total cost for all outings is ${totalCost}");
                        Console.WriteLine("\nPress enter to continue.");
                        Console.Read();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("What type of outing? (golf/bowling/amusement park/concert)");
                        int outingType;
                        switch (Console.ReadLine().ToLower())
                        {
                            case "golf":
                                outingType = 1;
                                break;
                            case "bowling":
                                outingType = 2;
                                break;
                            case "amusement park":
                                outingType = 3;
                                break;
                            case "concert":
                                outingType = 4;
                                break;
                            default:
                                outingType = 1;
                                break;
                        }
                        Console.Clear();
                        decimal TotalCost = 0.00m;
                        foreach (Outings outing in outingRepository.getOutingsByType(outingType))
                        {
                            TotalCost = TotalCost + outing.TotalCost;
                            Console.WriteLine($"{outing.Type}, {outing.Date.ToShortDateString()}, {outing.Headcount} people totaling ${outing.TotalCost}");
                        }
                        Console.WriteLine($"The total cost for this type is ${TotalCost}");
                        Console.WriteLine("\nPress enter to continue.");
                        Console.Read();
                        break;
                    default:
                        break;
                
                }
            }
        }

        static Outings newOuting()
        {
            Console.WriteLine("Type of outing (golf/bowling/amusement park/concert:");
            int outingType;
            switch (Console.ReadLine().ToLower())
            {
                case "golf":
                    outingType = 1;
                    break;
                case "bowling":
                    outingType = 2;
                    break;
                case "amusement park":
                    outingType = 3;
                    break;
                case "concert":
                    outingType = 4;
                    break;
                default:
                    outingType = 1;
                    break;
            }
            Console.Clear();

            Console.WriteLine("Date of Outing (m/d/y):");
            string[] accidentDate = Console.ReadLine().Split('/');
            DateTime outingDate = new DateTime(Int32.Parse(accidentDate[2]), Int32.Parse(accidentDate[0]), Int32.Parse(accidentDate[1]));
            Console.Clear();

            Console.WriteLine("Cost per person:");
            decimal costpp = decimal.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("How many people attended:");
            int headcount = Int32.Parse(Console.ReadLine());

            return new Outings(outingType, outingDate, costpp, headcount);
        }
    }
}

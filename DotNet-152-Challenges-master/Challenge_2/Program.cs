using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaimRepository claimRepository = new ClaimRepository();
            claimRepository.AddClaim(new Claim(1, "Fire in kitchen", 400.00m, DateTime.Now, DateTime.Now));
            while (true) {
                Console.Clear();
                Console.WriteLine("Choose a Menu Item:\n1. See all claims.\n2. Take care of next claim.\n3. Enter a new Claim\n4. Close");
                string Command = Console.ReadLine();
                if (Command == "1")
                {
                    DisplayDataSetup();
                    int row = 1;
                    foreach (Claim claim in claimRepository.GetClaims())
                    {
                        DisplayClaimInRow(claim, row);
                        row++;
                    }
                    Console.Read();
                    //-- See all claims
                }
                else if (Command == "2")
                {
                    Claim peekingClaim = claimRepository.GetNextClaim();
                    Console.Clear();
                    Console.WriteLine("Here are the details for the next claim to be handled: \n" +
                        $"ClaimID: {peekingClaim.ClaimID} \n" +
                        $"Type: {peekingClaim.ClaimType} \n" +
                        $"Description: {peekingClaim.Description} \n" +
                        $"Amount: ${peekingClaim.ClaimAmount} \n" +
                        $"DateOfClaim: {peekingClaim.DateOfClaim} \n" +
                        $"DateOfAccident: {peekingClaim.DateOfAccident} \n" +
                        $"IsValid: {peekingClaim.IsValid}"
                        );

                    Console.WriteLine("Do you want to handle this claim now? Y/N");
                    string yn = Console.ReadLine().ToLower();
                    if (yn == "y")
                    {
                        claimRepository.Dequeue();
                        claimRepository.AddClaim(newClaim());
                    }
                    else if (yn == "n")
                    {

                    }
                    //-- Take care of next claim
                }
                else if (Command == "3")
                {
                    claimRepository.AddClaim(newClaim());
                    //-- Enter a new Claim
                }
                else if (Command == "4")
                {
                    break;
                }
            }
        }

        static Claim newClaim()
        {
            Console.Clear();
            Console.WriteLine("Enter the claim type:");
            string claimType = Console.ReadLine().ToLower();
            int ClaimType;
            switch (claimType)
            {
                case "car":
                    ClaimType = 2;
                    break;
                case "house":
                    ClaimType = 1;
                    break;
                case "theft":
                    ClaimType = 3;
                    break;
                default:
                    ClaimType = 0;
                    break;
            }
            Console.Clear();

            Console.WriteLine("Enter a claim description");
            string Description = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Amount of Damage:");
            decimal Amount = Decimal.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Date of Accident (m/d/y):");
            string[] accidentDate = Console.ReadLine().Split('/');
            DateTime DateOfAccident = new DateTime(Int32.Parse(accidentDate[2]), Int32.Parse(accidentDate[0]), Int32.Parse(accidentDate[1]));
            Console.Clear();

            Console.WriteLine("Date of Claim (m/d/y):");
            string[] claimDate = Console.ReadLine().Split('/');
            DateTime DateOfClaim = new DateTime(Int32.Parse(claimDate[2]), Int32.Parse(claimDate[0]), Int32.Parse(claimDate[1]));
            Console.Clear();

            return new Claim(ClaimType, Description, Amount, DateOfAccident, DateOfClaim);
        }

        static void DisplayClaimInRow(Claim displayClaim, int row)
        {
            Console.SetCursorPosition(0, row);
            Console.Write(displayClaim.ClaimID);
            Console.SetCursorPosition(10, row);
            Console.Write(displayClaim.ClaimType);
            Console.SetCursorPosition(25, row);
            Console.Write(displayClaim.Description);
            Console.SetCursorPosition(55, row);
            Console.Write(displayClaim.ClaimAmount);
            Console.SetCursorPosition(65, row);
            Console.Write(displayClaim.DateOfAccident);
            Console.SetCursorPosition(85, row);
            Console.Write(displayClaim.DateOfClaim);
            Console.SetCursorPosition(100, row);
            Console.Write(displayClaim.IsValid);
        }

        static void DisplayDataSetup()
        {
            Console.Clear();
            //-- Setup
            Console.SetCursorPosition(0, 0);
            Console.Write("ClaimID");
            Console.SetCursorPosition(10, 0);
            Console.Write("ClaimType");
            Console.SetCursorPosition(25, 0);
            Console.Write("Description");
            Console.SetCursorPosition(55, 0);
            Console.Write("Amount");
            Console.SetCursorPosition(65, 0);
            Console.Write("DateOfAccident");
            Console.SetCursorPosition(85, 0);
            Console.Write("DateOfClaim");
            Console.SetCursorPosition(100, 0);
            Console.Write("IsValid");
        }
    }
}

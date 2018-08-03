using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class Claim
    {
        private enum ClaimTypes
        {
            House = 1,
            Car,
            Theft
        }

        public Claim(int claimType, string description, decimal claimAmount, DateTime dateOfAccident, DateTime dateOfClaim)
        {
            ClaimType = (ClaimTypes)claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfAccident = dateOfAccident.Date.ToString("d");
            DateOfClaim = dateOfClaim.Date.ToString("d");
            IsValid = (dateOfClaim - dateOfAccident).TotalDays <= 30;
        }

        public int ClaimID { get; set; }
        public Enum ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public string DateOfAccident { get; set; }
        public string DateOfClaim { get; set; }
        public bool IsValid { get; set; }
    }

    public class ClaimRepository
    {
        private Queue<Claim> ClaimList = new Queue<Claim>();
        private int TotalClaims = 0;

        public void AddClaim(Claim claim)
        {
            TotalClaims++;
            claim.ClaimID = TotalClaims;
            ClaimList.Enqueue(claim);
        }

        public Claim GetNextClaim()
        {
            return ClaimList.Peek();
        }

        public void Dequeue()
        {
            ClaimList.Dequeue();
        }

        public List<Claim> GetClaims()
        {
            return ClaimList.ToList();
        }
    }
}

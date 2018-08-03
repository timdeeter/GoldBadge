using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Challenge_2;

namespace Challenge_2_Tests
{
    [TestClass]
    public class UnitTest1
    {
        ClaimRepository claimRepo;
        [TestInitialize]
        public void Initialize()
        {
            claimRepo = new ClaimRepository();
            claimRepo.AddClaim(new Claim(1, "Fire in kitchen", 400.00m, DateTime.Now, DateTime.Now));
        }

        [TestMethod]
        public void Claim_ClaimRepository_CanAddClaim()
        {

            claimRepo.AddClaim(new Claim(2, "Wreck on IN-37", 2500.00m, DateTime.Now, DateTime.Now));
            claimRepo.Dequeue();
            //-- Act
            string actual = claimRepo.GetNextClaim().Description;
            string expected = "Wreck on IN-37";

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Claim_ClaimRepository_CanGetNextClaim()
        {
            //-- Act
            string actual = claimRepo.GetNextClaim().Description;
            string expected = "Fire in kitchen";

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Claim_ClaimRepository_GetClaimsAsList()
        {
            var FetchedClaims = claimRepo.GetClaims();
            Assert.IsInstanceOfType(FetchedClaims, typeof(List<Claim>));
        }
    }
}

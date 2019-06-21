using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepository
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }

        public bool IsValid
        {
            get
            {
                TimeSpan thirtyDays = DateOfClaim - DateOfIncident;
                if (thirtyDays.Days > 30)
                {
                    return false;
                }
                return true;
            }

        }

        public Claim() { }

        public Claim(int claimID, ClaimType claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

    }
}

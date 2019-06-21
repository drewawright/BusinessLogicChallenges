using _02_ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    class ProgramUI
    {
        private ClaimsRepository _claimsQueue = new ClaimsRepository();
        public void Run()
        {
            SeedClaimsList();
            RunUI();
        }

        private void RunUI()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Claims Department System\n" +
                    "Choose a menu item: \n" +
                    "1.See all claims \n" +
                    "2.Take care of next claim \n" +
                    "3.Enter a new claim \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        SeeNextClaimInQueue();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        Console.WriteLine("Thanks for using the Komodo Claims Department System.\n" +
                            "Press any key to exit");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 4");
                        break;
                }

            }

        }

        private void SeeAllClaims()
        {
            Queue<Claim> claimsQueue = _claimsQueue.GetClaimsList();
            Console.WriteLine("ClaimID   Type    Description             Amount      DateOfAccident  DateOfClaim      IsValid");
            foreach(Claim claim in claimsQueue)
            {
                Console.WriteLine($"{claim.ClaimID}   {claim.TypeOfClaim}    {claim.Description}            {claim.ClaimAmount}      {claim.DateOfIncident}  {claim.DateOfClaim}      {claim.IsValid}");
            }
            Console.WriteLine("End of List, press any key to continue...");
            Console.ReadKey();
        }

        private void SeeNextClaimInQueue()
        {
            Claim nextClaim = _claimsQueue.GetClaimFromQueue();
            Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.TypeOfClaim}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Claim Amount: ${nextClaim.ClaimAmount}\n" +
                $"Date of Accident: {nextClaim.DateOfIncident.Month}/{nextClaim.DateOfIncident.Day}/{nextClaim.DateOfIncident.Year}" +
                $"Date of Claim: {nextClaim.DateOfClaim.Month}/{nextClaim.DateOfClaim.Day}/{nextClaim.DateOfClaim.Year}\n" +
                $"IsValid: {nextClaim.IsValid}\n" +
                $" \n" +
                $"Would you like to deal with this claim now(y/n): ");
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                _claimsQueue.ActOnClaim();
            }
            else
            {
                Console.WriteLine("Returning to menu, press any key to continue...");
                Console.ReadKey();
            }

        }

        private void EnterNewClaim()
        {
            Claim newClaim = new Claim();
            Console.Write("Enter the Claim ID: ");
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of the Claim Type (1 = Car, 2 = Home, 3 = Theft): "); //in this short case, is a switch case better?
            int claimType = int.Parse(Console.ReadLine());
            newClaim.TypeOfClaim = (ClaimType)claimType;
            Console.Write("Enter the claim description: ");
            newClaim.Description = Console.ReadLine();
            Console.Write("Enter the amount of damage: $");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the date of the accident: ");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter the date of the Claim: ");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            if (newClaim.IsValid)
            {
                Console.WriteLine("This claim is valid");
            }
            else
            {
                Console.WriteLine("This claim is not valid");
            }
            _claimsQueue.AddClaimToQueue(newClaim);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedClaimsList()
        {
            Claim claimOne = new Claim(1, ClaimType.Car, "Backed into garage door", 100.00m, new DateTime(2019, 1, 14), new DateTime(2019, 1, 15));
            Claim claimTwo = new Claim(2, ClaimType.Home, "Son backed into garage door", 200.00m, new DateTime(2019, 1, 14), new DateTime(2019, 1, 15));
            Claim claimThree = new Claim(3, ClaimType.Theft, "Garage Door opener stolen", 25.00m, new DateTime(2019, 1, 25), new DateTime(2019, 2, 28));

            _claimsQueue.AddClaimToQueue(claimOne);
            _claimsQueue.AddClaimToQueue(claimTwo);
            _claimsQueue.AddClaimToQueue(claimThree);
        }
    }
}

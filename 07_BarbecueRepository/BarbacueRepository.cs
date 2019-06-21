using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BarbecueRepository
{
    public class BarbacueRepository
    {
        private List<Party> _partyList = new List<Party>();

        public List<Party> GetPartyList()
        {
            return _partyList;
        }

        public Party GetPartyFromList(DateTime partyDate)
        {
            foreach (Party party in _partyList)
            {
                if (party.PartyDate == partyDate)
                {
                    return party;
                }
            }
            return null;
        }

        public void AddPartyToList(Party party)
        {
            _partyList.Add(party);
        }

        public Booth GetBooth(DateTime partyDate, string boothType)
        {
            foreach (Party party in _partyList)
            {
                
                if(party.PartyDate == partyDate)
                {
                    if (boothType.ToLower() == "burger")
                    {
                        return party.BurgerBooth;
                    }
                    else if (boothType.ToLower() == "treat")
                    {
                        return party.TreatBooth;
                    }
                }
            }
            return null;
        }

        public void UpdateBooth(DateTime partyDate, Booth newBooth, string boothType)
        {
            if (boothType.ToLower() == "burger")
            {
                BurgerBooth newBurgerBooth = (BurgerBooth)newBooth;
                BurgerBooth oldBooth = (BurgerBooth)GetBooth(partyDate, boothType);
                oldBooth.HamburgerTickets = newBurgerBooth.HamburgerTickets;
                oldBooth.HotDogTickets = newBurgerBooth.HotDogTickets;
                oldBooth.VeggieBurgerTickets = newBurgerBooth.VeggieBurgerTickets;
            }
            else if (boothType.ToLower() == "treat")
            {
                TreatBooth oldBooth = (TreatBooth)GetBooth(partyDate, boothType);
                TreatBooth newTreatBooth = (TreatBooth)newBooth;
                oldBooth.IceCreamTickets = newTreatBooth.IceCreamTickets;
                oldBooth.PopcornTickets = newTreatBooth.PopcornTickets;
            }
        }

        public void DeletePartyFromList(DateTime partyDate)
        {
            Party deleteParty = GetPartyFromList(partyDate);
            _partyList.Remove(deleteParty);
        }

        public decimal GetCostOfAllParties(List<Party> partyList)
        {
            decimal finalCost = 0m;
            foreach(Party party in partyList)
            {
                finalCost += party.TotalPartyCost;
            }
            return finalCost;
        }
    }
}

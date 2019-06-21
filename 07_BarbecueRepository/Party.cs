using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BarbecueRepository
{
    public class Party 
    {
        public DateTime PartyDate { get; set; }
        public BurgerBooth BurgerBooth { get; set; }
        public TreatBooth TreatBooth { get; set; }
        public int TotalTicketsTaken
        {
            get
            {
                return BurgerBooth.TicketsTaken + TreatBooth.TicketsTaken;
            }
        }
        public decimal TotalPartyCost
        {
            get
            {
                return BurgerBooth.TotalCost + TreatBooth.TotalCost;
            }
        }

        public Party() { }

        public Party(DateTime partyDate, BurgerBooth burgerBooth, TreatBooth treatBooth)
        {
            PartyDate = partyDate;
            BurgerBooth = burgerBooth;
            TreatBooth = treatBooth;
        } 
    }
}

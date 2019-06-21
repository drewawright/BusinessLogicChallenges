using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BarbecueRepository
{
    public enum BoothType { Burger=1, Treat }
    public class Booth
    {
        public virtual BoothType TypeOfBooth { get; set; }
    }

    public class BurgerBooth : Booth
    {
        public new BoothType TypeOfBooth = BoothType.Burger;
        public int TicketsTaken
        {
            get
            {
                return HamburgerTickets + HotDogTickets + VeggieBurgerTickets;
            }
        }
        public int HamburgerTickets { get; set; }
        public decimal CostOfHamburgers
        {
            get
            {
                return HamburgerTickets * 1.25m;
            }
        }
        public int VeggieBurgerTickets { get; set; }
        public decimal CostOfVeggieBurgers
        {
            get
            {
                return VeggieBurgerTickets * 1.50m;
            }
        }
        public int HotDogTickets { get; set; }
        public decimal CostOfHotDogs
        {
            get
            {
                return HotDogTickets * 0.85m;
            }
        }
        public decimal TotalCost
        {
            get
            {
                return CostOfHamburgers + CostOfVeggieBurgers + CostOfHotDogs + 125.00m; //125.00 for misc costs
            } 
        }

        public BurgerBooth() { }
        public BurgerBooth(int hamburgerTickets, int veggieBurgerTickets, int hotDogTickets)
        {
            HotDogTickets = hotDogTickets;
            HamburgerTickets = hamburgerTickets;
            VeggieBurgerTickets = veggieBurgerTickets;
        }
    }

    public class TreatBooth : Booth
    {
        public new BoothType TypeOfBooth = BoothType.Treat;
        public int TicketsTaken
        {
            get
            {
                return IceCreamTickets + PopcornTickets;
            }
        }
        public int IceCreamTickets { get; set; }
        public decimal CostPerGallonOfIceCream
        {
            get
            {
                return (IceCreamTickets / 20) * 6.50m;
            }
        }
        public int PopcornTickets { get; set; }
        public decimal CostPerBagOfPopcorn
        {
            get
            {
                return PopcornTickets * 0.75m;
            }
        }
        public decimal TotalCost
        {
            get
            {
                return CostPerGallonOfIceCream + CostPerBagOfPopcorn + 95.75m; //95.75 for misc costs
            }
        }

        public TreatBooth() { }
        
        public TreatBooth(int iceCreamTickets, int popcornTickets)
        {
            IceCreamTickets = iceCreamTickets;
            PopcornTickets = popcornTickets;
        }
    }
}

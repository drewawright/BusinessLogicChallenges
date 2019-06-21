using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_OutingsRepository
{
    public enum OutingType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert,
        Undefined,
    }

    public class Outing
    {
        public string OutingTypeName { get; set; }
        public OutingType TypeOfOuting
        {
            get
            {
                switch (OutingTypeName)
                {
                    case "Golf":
                        return OutingType.Golf;
                    case "Bowling":
                        return OutingType.Bowling;
                    case "Amusement Park":
                        return OutingType.AmusementPark;
                    case "Concert":
                        return OutingType.Concert;
                    default:
                        return OutingType.Undefined;
                }
            }
        }
        public DateTime EventDate { get; set; }
        public int NumberAttending { get; set; }
        public decimal CostPerPerson
        {
            get
            {
                switch (TypeOfOuting)
                {
                    case OutingType.Golf:
                        return 75.00m;
                    case OutingType.Bowling:
                        return 25.00m;
                    case OutingType.AmusementPark:
                        return 100.00m;
                    case OutingType.Concert:
                        return 55.00m;
                    default:
                        return 0.00m;
                }
            }
        }
        public decimal TotalCost
        {
            get { return NumberAttending * CostPerPerson; }
        }

        public Outing() { }

        public Outing(string outingTypeName, DateTime eventDate, int numberAttending)
        {
            OutingTypeName = outingTypeName;
            EventDate = eventDate;
            NumberAttending = numberAttending;
        }
    }
}

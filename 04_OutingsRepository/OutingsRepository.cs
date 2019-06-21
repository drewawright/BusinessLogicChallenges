using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_OutingsRepository
{
    public class OutingsRepository
    {
        private List<Outing> _outingsList = new List<Outing>();

        public List<Outing> GetListOfOutings()
        {
            return _outingsList;
        }

        public void AddOutingToList(Outing outing)
        {
            _outingsList.Add(outing);
        }

        public decimal GetCostOfAllOutings()
        {
            decimal totalCost = 0m;
            foreach (Outing outing in _outingsList)
            {
                totalCost += outing.TotalCost;
            }
            return totalCost;
        }

        public decimal GetCostOfOutingsType(OutingType outingType)
        {
            decimal totalCost = 0m;
            foreach (Outing outing in _outingsList)
            {
                if (outing.TypeOfOuting == outingType)
                {
                    totalCost += outing.TotalCost;
                }
            }
            return totalCost;
        }
    }
}

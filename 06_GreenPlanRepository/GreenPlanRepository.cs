using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlanRepository
{
    public class GreenPlanRepository
    {
        private List<ICar> _carsList = new List<ICar>();

        public List<ICar> GetCarsList()
        {
            return _carsList;
        }

        public void AddCarToList(ICar car)
        {
            _carsList.Add(car);
        }

        public ICar GetCarFromList(string model)
        {
            foreach(ICar car in _carsList)
            {
                if (car.Model.ToLower() == model.ToLower())
                {
                    return car;
                }
            }
            return null;
        }

        public void UpdateCarOnList(string oldModel, ICar car)
        {
            ICar oldCar = GetCarFromList(oldModel);
            oldCar.Make = car.Make;
            oldCar.Model = car.Model;
            oldCar.MPG = car.MPG;
            oldCar.Price = car.Price;
            oldCar.NumberOfDrivers = car.NumberOfDrivers;
        }

        public void DeleteCarFromList(string model)
        {
            ICar car = GetCarFromList(model);
            _carsList.Remove(car);
        }
    }
}

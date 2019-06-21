using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_SmartInsuranceRepository
{
    public class SmartInsuranceRepository
    {
        private List<DriverData> _driverDataRepo = new List<DriverData>();
        private Dictionary<int, Driver> _driverDict = new Dictionary<int, Driver>();

        public void AddDriverToDict(Driver driver)
        {
            _driverDict.Add(driver.DriverID, driver);
        }

        public Dictionary<int, Driver> GetFullDriverDict()
        {
            return _driverDict;
        }

        public Driver GetOneDriver(int driverID)
        {
            return _driverDict[driverID];
        }

        public void EditDriver(int driverID, Driver updateDriver)
        {
            Driver oldDriver = GetOneDriver(driverID);
            oldDriver.DriverID = updateDriver.DriverID;
            oldDriver.DriverName = updateDriver.DriverName;
            updateDriver.DriverData = updateDriver.DriverData;
        }

        public List<DriverData> GetDriverData()
        {
            foreach (KeyValuePair<int, Driver> driver in _driverDict)
            {
                _driverDataRepo.Add(driver.Value.DriverData);
            }
            return _driverDataRepo;
        }

        public DriverData GetOneDriversData(int driverID)
        {
            return GetOneDriver(driverID).DriverData;
        }

        public void EditDriverData(int driverID, DriverData updateData)
        {
            Driver oldDriver = _driverDict[driverID];
            oldDriver.DriverData.SpeedingFrequency = updateData.SpeedingFrequency;
            oldDriver.DriverData.OutOfLaneFrequency = updateData.OutOfLaneFrequency;
            oldDriver.DriverData.FollowingTooCloselyFrequency = updateData.FollowingTooCloselyFrequency;
            oldDriver.DriverData.TimesRollingThroughStopSign = updateData.TimesRollingThroughStopSign;
        }
        
        public void RemoveDriverFromDict(int driverID)
        {
            _driverDict.Remove(driverID);
        }

        public DriverData GetAverageData(List<DriverData> driverData)
        {
            DriverData averageData = new DriverData();
            foreach (DriverData data in driverData)
            {
                averageData.SpeedingFrequency += data.SpeedingFrequency;
                averageData.OutOfLaneFrequency += data.OutOfLaneFrequency;
                averageData.FollowingTooCloselyFrequency += data.FollowingTooCloselyFrequency;
                averageData.TimesRollingThroughStopSign += data.FollowingTooCloselyFrequency;
            }
            averageData.SpeedingFrequency /= driverData.Count;
            averageData.OutOfLaneFrequency /= driverData.Count;
            averageData.FollowingTooCloselyFrequency /= driverData.Count;
            averageData.TimesRollingThroughStopSign /= driverData.Count;
            return averageData;
        }
    }
}

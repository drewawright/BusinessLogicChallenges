using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_SmartInsuranceRepository
{
    public enum SafetyClass
    {
        VerySafe=1,
        Safe,
        Average,
        Risky,
        Reckless
    }

    public class Driver
    {
        public int DriverID { get; set; }
        public decimal Premium
        {
            get
            {
                decimal initialPremium = 100.00m;
                if (DriverClass == SafetyClass.VerySafe) return initialPremium + 50.50m;
                else if (DriverClass == SafetyClass.Safe) return initialPremium + 75.25m;
                else if (DriverClass == SafetyClass.Average) return initialPremium + 100.02m;
                else if (DriverClass == SafetyClass.Risky) return initialPremium + 190.98m;
                else return initialPremium + 278.34m;
            }
        }
        public string DriverName { get; set; }
        public DriverData DriverData { get; set; }
        public int SafetyScore
        {
            get { return 100 - DriverData.SpeedingFrequency - DriverData.OutOfLaneFrequency - DriverData.FollowingTooCloselyFrequency - DriverData.TimesRollingThroughStopSign; }
        }
        public SafetyClass DriverClass
        {
            get
            {
                if (SafetyScore > 94) return SafetyClass.VerySafe;
                else if (SafetyScore > 84) return SafetyClass.Safe;
                else if (SafetyScore > 70) return SafetyClass.Average;
                else if (SafetyScore > 50) return SafetyClass.Risky;
                else return SafetyClass.Reckless;
            }
        }

        public Driver() { }

        public Driver(int driverID, string driverName, DriverData driverData)
        {
            DriverID = driverID;
            DriverName = driverName;
            DriverData = driverData;
        }
    }

    public class DriverData
    {
        private int _speedingFrequency;

        public int SpeedingFrequency
        {
            get { return _speedingFrequency; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                    _speedingFrequency = value;
                }
                else if (value > 100)
                {
                    value = 100;
                    _speedingFrequency = value;
                }
                else _speedingFrequency = value;
            }
        }

        private int _outOfLaneFrequency;

        public int OutOfLaneFrequency
        {
            get { return _outOfLaneFrequency; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                    _outOfLaneFrequency = value;
                }
                else if (value > 100)
                {
                    value = 100;
                    _outOfLaneFrequency = value;
                }
                else _outOfLaneFrequency = value;
            }
        }

        private int _followingTooCloselyFrequency;

        public int FollowingTooCloselyFrequency
        {
            get { return _followingTooCloselyFrequency; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                    _followingTooCloselyFrequency = value;
                }
                else if (value > 100)
                {
                    value = 100;
                    _followingTooCloselyFrequency = value;
                }
                else _followingTooCloselyFrequency = value;
            }
        }

        public int TimesRollingThroughStopSign { get; set; }

        public DriverData() { }

        public DriverData(int speedingFrequency, int outOfLaneFrequency, int followingTooCloselyFrequency, int timesRollingThroughStopSign)
        {
            SpeedingFrequency = speedingFrequency;
            OutOfLaneFrequency = outOfLaneFrequency;
            FollowingTooCloselyFrequency = followingTooCloselyFrequency;
            TimesRollingThroughStopSign = timesRollingThroughStopSign;
        }
    }
}

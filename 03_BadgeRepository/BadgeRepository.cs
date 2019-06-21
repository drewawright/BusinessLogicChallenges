using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeRepository
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeRepo = new Dictionary<int, List<string>>();

        public Dictionary<int, List<string>> GetBadgeList()
        {
            return _badgeRepo;
        }

        public void AddBadgetoList(Badge badge)
        {
            _badgeRepo.Add(badge.BadgeID, badge.DoorsAccessible);
        }

        public Badge GetBadgeFromList(int badgeID)
        {
            Badge badge = new Badge(badgeID, _badgeRepo[badgeID]);
            return badge;
        }

        public void AddDoorToBadge(int badgeID, string doorToAdd)
        {
            Badge badge = GetBadgeFromList(badgeID);
            badge.DoorsAccessible.Add(doorToAdd);
            _badgeRepo[badgeID] = badge.DoorsAccessible;
        }

        public void RemoveDoorFromBadge(int badgeID, string doorToRemove)
        {
            Badge badge = GetBadgeFromList(badgeID);
            badge.DoorsAccessible.Remove(doorToRemove);
            _badgeRepo[badgeID] = badge.DoorsAccessible;
        }

        public void RemoveAllDoorsFromBadge(int badgeID)
        {
            _badgeRepo[badgeID].Clear();
        }
    }
}

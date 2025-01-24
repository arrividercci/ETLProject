using ETLProject.Data.Models;

namespace ETLProject.Data.Helpers
{
    public class TripCsvComparer : IEqualityComparer<TripCsv>
    {
        public bool Equals(TripCsv x, TripCsv y)
        {
            return x.PickupDateTime == y.PickupDateTime &&
                   x.DropoffDateTime == y.DropoffDateTime &&
                   x.PassengerCount == y.PassengerCount;
        }

        public int GetHashCode(TripCsv obj)
        {
            return HashCode.Combine(obj.PickupDateTime, obj.DropoffDateTime, obj.PassengerCount);
        }
    }
}

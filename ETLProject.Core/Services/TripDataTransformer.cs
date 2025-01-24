using ETLProject.Core.Interfaces;
using ETLProject.Data.Models;

namespace ETLProject.Core.Services
{
    public class TripDataTransformer : IDataTransformer<TripCsv>
    {
        public IEnumerable<TripCsv> GetUnique(IEnumerable<TripCsv> trips, IEqualityComparer<TripCsv> comparer)
        {
            return trips.Distinct(comparer).ToList();
        }

        public void Transform(IEnumerable<TripCsv> data)
        {
            foreach (var trip in data)
            {
                if (trip.StoreAndFwdFlag != null)
                {
                    trip.StoreAndFwdFlag = trip.StoreAndFwdFlag == "Y" ? "Yes" : "No";
                }
            }
        }
    }
}

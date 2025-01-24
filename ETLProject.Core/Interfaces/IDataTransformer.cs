using ETLProject.Data;

namespace ETLProject.Core.Interfaces
{
    public interface IDataTransformer<T>
    {
        IEnumerable<T> GetUnique(IEnumerable<T> trips, IEqualityComparer<T> comparer);
        void Transform(IEnumerable<T> data);
    }
}

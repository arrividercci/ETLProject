namespace ETLProject.Core.Interfaces
{
    public interface IFileWriter
    {
        public Task WriteAsync<T>(IEnumerable<T> data);
    }
}

namespace ETLProject.Core.Interfaces
{
    public interface IDataExtractor
    {
        Task<string> ExtractAsync();
    }
}

namespace ETLProject.Core.Interfaces
{
    public interface IModelExtractor
    {
        Task<IEnumerable<T>> ExtractModelsAsync<T>(string data);
    }
}

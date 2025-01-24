using ETLProject.Core.Interfaces;

namespace ETLProject.Core.Services
{
    public class FileDataExtractor : FileHandler, IDataExtractor
    {
        public FileDataExtractor(string filepath) : base(filepath)
        {
        }

        public async Task<string> ExtractAsync()
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file at path '{filePath}' does not exist.");
            }

            using (var reader = new StreamReader(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}

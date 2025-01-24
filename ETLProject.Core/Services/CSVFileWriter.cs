using CsvHelper;
using ETLProject.Core.Interfaces;
using System.Globalization;

namespace ETLProject.Core.Services
{
    public class CSVFileWriter : FileHandler, IFileWriter
    {
        public CSVFileWriter(string filepath) : base(filepath)
        {
        }

        public async Task WriteAsync<T>(IEnumerable<T> data)
        {
            try
            {
                bool fileExists = File.Exists(filePath);
                using (var streamWriter = new StreamWriter(filePath, append: fileExists))
                using (var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    if (!fileExists)
                    {
                        csv.WriteHeader<T>();
                    }
                    await csv.WriteRecordsAsync(data);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
    }
}

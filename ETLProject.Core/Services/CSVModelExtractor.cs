using CsvHelper.Configuration;
using CsvHelper;
using ETLProject.Core.Interfaces;
using System.Globalization;
namespace ETLProject.Core.Services
{
    public class CSVModelExtractor : IModelExtractor
    {
        public async Task<IEnumerable<T>> ExtractModelsAsync<T>(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Input data cannot be null or empty.", nameof(data));
            }

            using (var reader = new StringReader(data))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                TrimOptions = TrimOptions.Trim,
                IgnoreBlankLines = true,
                HeaderValidated = null,
                BadDataFound = context =>
                {
                    Console.WriteLine($"Bad data: {context.RawRecord}");
                },
                MissingFieldFound = index => { Console.WriteLine(); },
                InjectionOptions = InjectionOptions.Escape,
            }))
            {
                var records = await Task.Run(() => csv.GetRecords<T>());
                return records.ToList();
            }
        }
    }
}

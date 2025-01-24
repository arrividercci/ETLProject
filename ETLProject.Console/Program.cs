using ETLProject.Core.Interfaces;
using ETLProject.Core.Services;
using ETLProject.Data.Helpers;
using ETLProject.Data.Models;
using ETLProject.Data.Services;
using System.Data;

if (args.Length != 2)
{
    Console.WriteLine("Usage: ETLProject <filepath> <connectionString>");
    return;
}

string filepath = args[0];
string connectionString = args[1];
const string duplicateFilepath = "duplicate.csv";
try
{
    // Extract data
    IDataExtractor dataExtractor = new FileDataExtractor(filepath);
    string data = await dataExtractor.ExtractAsync();

    // Transform data
    IModelExtractor modelExtractor = new CSVModelExtractor();
    var trips = await modelExtractor.ExtractModelsAsync<TripCsv>(data);
    IDataTransformer<TripCsv> tripDataTransform = new TripDataTransformer();
    var uniqueTrips = tripDataTransform.GetUnique(trips, new TripCsvComparer());
    var duplicateTrips = trips.Except(uniqueTrips).ToList();
    var csvFileWriter = new CSVFileWriter(duplicateFilepath);
    await csvFileWriter.WriteAsync(duplicateTrips);
    tripDataTransform.Transform(uniqueTrips);

    //Load
    var sqlServerService = new SqlServerService(connectionString);
    var dataTable = new DataTable();
    dataTable.Columns.Add("PickupDateTime", typeof(DateTime));
    dataTable.Columns.Add("DropoffDateTime", typeof(DateTime));
    dataTable.Columns.Add("PassengerCount", typeof(int));
    dataTable.Columns.Add("TripDistance", typeof(double));
    dataTable.Columns.Add("StoreAndFwdFlag", typeof(string));
    dataTable.Columns.Add("PULocationID", typeof(int));
    dataTable.Columns.Add("DOLocationID", typeof(int));
    dataTable.Columns.Add("FareAmount", typeof(decimal));
    dataTable.Columns.Add("TipAmount", typeof(decimal));

    foreach (var trip in uniqueTrips)
    {
        var pickupDateTimeUtc = DateTimeConverter.ConvertESTToUTC(trip.PickupDateTime);
        var dropoffDateTimeUtc = DateTimeConverter.ConvertESTToUTC(trip.DropoffDateTime);

        dataTable.Rows.Add(
            pickupDateTimeUtc,
            dropoffDateTimeUtc,
            trip.PassengerCount,
            trip.TripDistance,
            trip.StoreAndFwdFlag,
            trip.PULocationID,
            trip.DOLocationID,
            trip.FareAmount,
            trip.TipAmount);
}
await sqlServerService.InsertDataAsync("Trips", dataTable);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}
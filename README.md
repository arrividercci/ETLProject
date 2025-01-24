# ETL Project

This project is designed to perform ETL (Extract, Transform, Load) operations to process data from a CSV file into an SQL Server database.

## Step 1: Prepare the Database

Before running the program, you need to create a database in SQL Server. Execute the following SQL commands:

```sql
CREATE DATABASE TripData;

USE TripData;

CREATE TABLE Trips (
    PickupDateTime DATETIME,
    DropoffDateTime DATETIME,
    PassengerCount INT,
    TripDistance FLOAT,
    StoreAndFwdFlag VARCHAR(3),
    PULocationID INT,
    DOLocationID INT,
    FareAmount DECIMAL(18, 2),
    TipAmount DECIMAL(18, 2)
);

CREATE INDEX IX_Trips_PULocationID ON Trips (PULocationID);

CREATE INDEX IX_Trips_TripDistance ON Trips (TripDistance);

CREATE INDEX IX_Trips_DropoffDateTime ON Trips (DropoffDateTime);
```

## Step 2: Download the data file for processing:
https://drive.google.com/file/d/1l2ARvh1-tJBqzomww45TrGtIh5j8Vud4/view?usp=sharing
## Step 3: Set Up the Environment

### Clone or download the repository:

git clone <repository_url>

### Navigate to the project folder:

cd ETLProject

## Step 4: Build the Project

dotnet build

## Step 5: Run the Project

dotnet run <path_to_file> <connection_string>

# Number of rows in your table after running the program:

29889

# Assume your program will be used on much larger data files. Describe in a few sentences what you would change if you knew it would be used for a 10GB CSV input fil:

Instead of loading the entire file into memory, I'd process the file in parts or chunk-by-chunk. This would allow handling large files without requiring all data to be held in memory at once.


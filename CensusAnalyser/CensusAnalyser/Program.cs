using System;

namespace CensusAnalyser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Indian Census Analyser");
            string FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCensusData.csv";
            string STATE_CODE_FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCode.csv";
            int CSVStateRecord = CSVStateCensus.GetCensusRecord(FILE_PATH);
            int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(FILE_PATH);
            Console.WriteLine("Fetch CSV data for State Census {0} \n state Census Data {1}", CSVStateRecord, StateCensusRecord);
            StateCensusAnalyser.PrintData(FILE_PATH);

            new CSVConvert(FILE_PATH).SortByState();
            new CSVConvert(STATE_CODE_FILE_PATH).SortByStateCode();
            new CSVConvert(FILE_PATH).SortByStatePopullation();
            new CSVConvert(FILE_PATH).SortByStatePopullationDensity();
            new CSVConvert(FILE_PATH).SortByStateLagestArea();
        }
    }
}

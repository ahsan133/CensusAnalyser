using System;

namespace CensusAnalyser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Indian Census Analyser");
            string FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCensusData.csv";
            string US_SENSUS_FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\USCensusData.csv";

            string state = new CSVConvert(FILE_PATH).MostPopulatedState();
            string USState = new CSVConvert(US_SENSUS_FILE_PATH).MostPopulatedState();
            Console.WriteLine("most populated state in india : " + state + "\nmost populated state in us : " + USState);
        }
    }
}
